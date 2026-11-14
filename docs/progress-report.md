# Báo cáo tiến độ – wtranslu (fork RSTGameTranslation)

Cập nhật: 15/11/2026 04:00 (giờ VN). Bản này được cập nhật dần; bản cuối kèm ảnh nằm ở link báo cáo gửi riêng.

## Nhánh

| Nhánh | Nội dung | Dựa trên |
|---|---|---|
| `main` | Mã RST 6.2 gốc (GPLv3) | – |
| `claude/amazing-hamilton-lddsx3` | Bộ kiểm thử: game giả, chế độ tự động, CSV đo thời gian, CI Windows | `main` |
| `fix-wgc-latest-frame` | Sửa lỗi RST gốc: khung hình chụp cửa sổ bị cũ ~200 ms | nhánh trên |
| `goal1-translation-cache` | Mục tiêu 1: cache 2 tầng lưu theo game | `fix-...` |
| `goal2-font-size` | Mục tiêu 2: cỡ chữ theo chiều cao dòng | `goal1` |
| `goal3-colors` | Mục tiêu 3: màu chữ, nền, viền, bóng | `goal2` |
| `goal4-game-font` | Mục tiêu 4: font theo game, có dấu tiếng Việt | `goal3` |
| `goal5-word-colors` | Mục tiêu 5: từ khác màu qua thẻ màu cho LLM | `goal4` |

Ảnh chụp và số liệu thô của mọi lần chạy CI: nhánh `ci-evidence`, thư mục `<nhánh>/run<N>/`.

## Số đo mục tiêu 1 (game giả có hình động, OneOCR, Google Translate, máy ảo Windows của GitHub)

Độ trễ = từ lúc câu thoại hiện trên game đến lúc bản dịch hiện trên lớp phủ.

| Bản | Câu lặp lại (cùng phiên) | Sau khi tắt/mở lại app | Số lần OCR (32 câu) | Request dịch sau khi mở lại |
|---|---|---|---|---|
| RST gốc | 1347 ms | 1346 ms | 337 | 15 |
| + sửa khung hình | 1021 ms | 1096 ms | 254 | 12 |
| + mục tiêu 1 | 489 ms | 580 ms | 60 | 0 |

## Trạng thái

- Mục tiêu 1–4: đã làm, đã chạy CI có ảnh minh chứng; đang tinh chỉnh theo kết quả đo.
- Mục tiêu 5: đã làm; đang chạy CI với LLM thật (Ollama qwen2.5:3b trên máy ảo).
