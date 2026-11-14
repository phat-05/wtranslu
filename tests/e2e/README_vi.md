# Tự kiểm tra trên game thật

## 1. Lấy bản build

- **Cách nhanh:** vào tab *Actions* của repo, mở lần chạy mới nhất của nhánh `goal5-word-colors`, tải artifact `rst-build`. Giải nén ra một thư mục rồi chạy `rst.exe`.
- **Tự build** (Windows, cài .NET 9 SDK):

```bat
git clone -b goal5-word-colors https://github.com/phat-05/wtranslu
cd wtranslu
dotnet build RST.csproj -c Release -p:CsWinRTGenerateProjection=false -p:CsWinRTIIDOptimizerOptOut=true
copy app\OneOcr\* app\
app\rst.exe
```

## 2. Đo độ trễ trước và sau (mục tiêu 1)

1. Mở `cmd`, đặt file ghi số đo, rồi mở RST **từ chính cửa sổ cmd đó**:

```bat
set RST_METRICS_FILE=%TEMP%\rst_truoc.csv
app\rst.exe
```

2. **"Trước"**: vào *Settings → Translation speed*, bỏ chọn 3 ô *Lưu cache ra file*, *Dùng lại cả khi OCR đọc lệch*, *Nhận ra chữ đã đọc qua điểm ảnh*, rồi bấm *Xoá cache của game này*.
3. Chọn cửa sổ game (*Select Application*), bấm *Start*. Chơi khoảng 5 phút ở đoạn có chữ lặp lại: nói chuyện lại với một NPC, mở và đóng menu, đọc lại bảng hướng dẫn. Sau đó tắt RST.
4. Làm lại các bước 1–3 với `set RST_METRICS_FILE=%TEMP%\rst_sau.csv`. Lần này **bật lại** 3 ô trên, chơi đúng đoạn đó. Rồi **tắt RST, mở lại**, chơi thêm 2 phút để thấy cache được giữ sau khi khởi động lại.
5. Xem kết quả (cần Python 3):

```bat
python tests\e2e\latency_report.py %TEMP%\rst_truoc.csv
python tests\e2e\latency_report.py %TEMP%\rst_sau.csv
```

Script in ra độ trễ của từng câu (từ khung hình có chữ đến lúc bản dịch hiện) và câu đó được lấy từ đâu:

| Nhãn | Ý nghĩa |
|---|---|
| `image` | cache ảnh, không chạy OCR |
| `cache` | cache văn bản |
| `fuzzy` | cache văn bản, OCR đọc lệch một chút |
| `net` | gửi request dịch qua mạng |

Ở bản "sau", các câu lặp lại phải chủ yếu là `image` hoặc `cache`, độ trễ thấp hơn rõ rệt, và số lần OCR ít hơn.

File cache nằm trong thư mục `Cache` cạnh `rst.exe`, mỗi game một file:

- `<game>.<nguồn>-<đích>.jsonl`: bản dịch. Mở bằng Notepad để sửa tay câu dịch sai, mỗi dòng là một câu.
- `<game>.<nguồn>.<OCR>.images.jsonl`: dấu vân tay ảnh của các dòng chữ.

## 3. Kiểm tra mục tiêu 2–5

Mở *Overlay options* (nút cài đặt của lớp phủ):

| Mục tiêu | Tuỳ chọn | Cách kiểm tra |
|---|---|---|
| 2. Cỡ chữ | *Cỡ chữ bản dịch theo chiều cao dòng chữ của game* | Bật/tắt rồi so: tiêu đề, banner chữ to phải ra chữ dịch to tương ứng. Câu dịch dài hơn thì lấn sang khoảng trống bên phải trước, chỉ co lại khi hết chỗ. |
| 3. Màu | *Giữ màu chữ, viền và bóng đổ của game* | Chữ vàng ra chữ vàng, chữ màu nhạt không bị đổi thành đen hoặc trắng, phụ đề có viền đen thì bản dịch cũng có viền đen. |
| 4. Font | *Font cho game này* | Danh sách chỉ có font đủ dấu tiếng Việt. Muốn dùng font giống game thì chép file `.ttf`/`.otf` (có dấu tiếng Việt) vào thư mục `Fonts` cạnh `rst.exe`, mở lại RST rồi chọn. Font được lưu theo từng game (theo tên profile, nếu không có profile thì theo tên file .exe của game). |
| 5. Từ khác màu | *Tô màu từng từ như game* | Cần dịch bằng AI (Gemini, ChatGPT, Ollama, ...). Câu có tên vật phẩm hoặc nhân vật khác màu thì bản dịch tô đúng cụm từ tương ứng. Với Google Translate chỉ tô được tên riêng và số giữ nguyên. |

## 4. Giới hạn đã biết

- Cache ảnh nhận ra chữ ở **các vị trí đã từng đọc**. Nếu chữ mới hiện ở chỗ khác trong khi chữ cũ vẫn còn, thì phải đến lần OCR kiểm tra tiếp theo (tối đa 8 khung, khoảng 2 giây) mới thấy.
- Viền chữ được vẽ bằng một quầng mỏng quanh chữ, nên không sắc nét bằng viền thật trong game.
- Mô hình AI nhỏ (3B) giữ thẻ màu được nhưng dịch kém. Nên dùng mô hình lớn hơn hoặc dịch vụ trên mạng.
