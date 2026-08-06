# Câu 1: Giải thích vì sao Task.WhenAll chạy nhanh hơn foreach + await, dựa trên con số Stopwatch thực tế bạn đo được (song song ~1.3s, tuần tự ~5.2s).
- task.whenAll chạy song song toàn bộ task, còn foreach + await chạy từng task cụ thể 1.3 cho whenAll, và 5.2 cho foreach+ await.
# Câu 2: Điều gì sẽ xảy ra nếu bạn gọi .Result thay vì await trong một ứng dụng ASP.NET Core thật — tại sao nó nguy hiểm (giải thích khái niệm deadlock ở mức bạn hiểu được, không cần quá sâu).
- .Result sẽ không nhả luồng nó đang giữ. Nếu trong đó có await thì nó sẽ cần luồng mà .Result đang giữ để chạy => deadlock.
- await chủ động nhường luồng đang giữ để await khác chạy nên không xảy ra deadlock như result