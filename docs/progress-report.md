# Báo cáo tiến độ – wtranslu (fork RSTGameTranslation)

Cập nhật: 15/11/2026 06:30 (giờ VN). **Cả 5 mục tiêu đã xong.** Báo cáo đầy đủ có ảnh trước/sau: https://claude.ai/artifact/1ppoLJjYjzsZbYgdJP11tP

## Pull Request (xếp chồng, merge lần lượt #1 → #7, chưa merge)

| PR | Nhánh | Nội dung |
|---|---|---|
| #1 | `claude/amazing-hamilton-lddsx3` → `main` | Bộ kiểm thử: game giả, chế độ tự động, CSV đo, CI Windows |
| #2 | `fix-wgc-latest-frame` | Sửa lỗi RST gốc: khung hình chụp cửa sổ cũ khoảng 200 ms |
| #3 | `goal1-translation-cache` | Cache 2 tầng theo game |
| #4 | `goal2-font-size` | Cỡ chữ theo chiều cao dòng |
| #5 | `goal3-colors` | Màu chữ, nền, viền, bóng |
| #6 | `goal4-game-font` | Font theo game, đủ dấu tiếng Việt |
| #7 | `goal5-word-colors` | Từ khác màu qua thẻ màu cho AI; hướng dẫn kiểm tra `tests/e2e/README_vi.md` |

## Số đo chính

Đo trên game giả có hình động, máy ảo Windows của GitHub, OneOCR + Google Translate, 32 câu.

| | RST gốc | Bản cuối |
|---|---|---|
| Câu lặp lại, trung bình | 1347 ms | 478–603 ms (3 lần chạy) |
| Sau khi tắt/mở lại app | 1346 ms | 551–713 ms |
| Số lần OCR | 337 | 56–61 |
| Request dịch sau khi mở lại app | 15 | 1–2 |
| Cỡ chữ bản dịch / cỡ chữ game | 83% | 97% |

Ảnh và số liệu thô: nhánh `ci-evidence`.
