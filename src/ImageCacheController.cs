using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using RSTGameTranslation.Cache;

namespace RSTGameTranslation
{
    /// <summary>
    /// Connects the image tier of the cache (Cache.ImageTextCache) to the capture loop: before a
    /// frame goes to OCR it is looked up by its pixels, and after a real OCR the result is stored
    /// with the pixels it came from. One cache per game, OCR source language and OCR engine, kept in
    /// Cache\&lt;game&gt;.&lt;language&gt;.&lt;engine&gt;.images.jsonl.
    /// All calls come from the UI thread (the capture timer and the OCR result handler).
    /// </summary>
    public static class ImageCacheController
    {
        private static ImageTextCache? _cache;
        private static string _scope = "";

        // Pixels of the frame being OCR'd, kept until its result comes back
        private static byte[] _pending = Array.Empty<byte>();
        private static int _pendingW, _pendingH, _pendingStride;
        private static bool _hasPending;

        private static byte[] _buffer = Array.Empty<byte>();

        public static int Count => _cache?.Count ?? 0;

        /// <summary>
        /// Looks the frame up. On a hit returns the OCR result to use instead of running OCR.
        /// On a miss returns null and keeps the frame's pixels for OnOcrResult.
        /// </summary>
        public static string? TryServe(Bitmap frame, string sourceLanguage, string ocrMethod)
        {
            _hasPending = false;
            if (!ConfigManager.Instance.IsImageTextCacheEnabled())
                return null;

            try
            {
                var cache = CacheFor(sourceLanguage, ocrMethod);
                int stride = CopyPixels(frame, ref _buffer);
                if (stride == 0)
                    return null;

                string? json = cache.Lookup(_buffer, frame.Width, frame.Height, stride, out int lines);
                if (json != null)
                {
                    OcrTiming.MarkImageCacheHit(lines);
                    return json;
                }

                // Keep this frame for the OCR result (swap buffers instead of copying)
                (_pending, _buffer) = (_buffer, _pending);
                _pendingW = frame.Width;
                _pendingH = frame.Height;
                _pendingStride = stride;
                _hasPending = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image cache lookup failed: {ex.Message}");
            }
            return null;
        }

        /// <summary>A real OCR result for the frame kept by the last TryServe miss.</summary>
        public static void OnOcrResult(string ocrJson)
        {
            if (!_hasPending || _cache == null)
                return;
            _hasPending = false;
            try
            {
                if (!_cache.OnOcrResult(ocrJson, _pending, _pendingW, _pendingH, _pendingStride))
                    OcrTiming.Log("0. Image cache entry dropped", "OCR read something else at its place");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image cache store failed: {ex.Message}");
            }
        }

        public static void DeleteCurrent()
        {
            _cache?.Clear();
            _hasPending = false;
        }

        private static ImageTextCache CacheFor(string sourceLanguage, string ocrMethod)
        {
            bool persistent = ConfigManager.Instance.IsTranslationCachePersistent();
            string scope = $"{GameIdentity.FileSafe(GameIdentity.Current)}.{sourceLanguage}.{GameIdentity.FileSafe(ocrMethod.Replace(" ", ""))}.images";
            string key = scope + (persistent ? "" : "|memory");
            if (_cache == null || key != _scope)
            {
                _cache = new ImageTextCache(persistent ? Path.Combine(TranslationCache.CacheFolder, scope + ".jsonl") : null);
                _scope = key;
                _hasPending = false;
                Console.WriteLine($"Image cache: {scope} ({_cache.Count} entries)");
            }
            return _cache;
        }

        // Copies the bitmap as 32-bit BGRA into buffer (grown when needed); returns the stride, 0 on failure
        private static int CopyPixels(Bitmap bitmap, ref byte[] buffer)
        {
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                int stride = data.Stride;
                if (stride <= 0)
                    return 0;
                int length = stride * bitmap.Height;
                if (buffer.Length < length)
                    buffer = new byte[length];
                Marshal.Copy(data.Scan0, buffer, 0, length);
                return stride;
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }
    }
}
