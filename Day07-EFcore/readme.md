# (1) EF Core đang lưu Employee/FullTimeEmployee/PartTimeEmployee/Intern theo chiến lược kế thừa nào (TPH hay TPT)? Bạn thấy bằng chứng của điều đó ở đâu trong Migration? Đánh đổi (trade-off) của chiến lược đó là gì?
-TPH. Tôi thấy có Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false) đây là cột để lưu. Đánh đổi là có nhiều cột null.

# (2) DbContext (AppDbContext) có phải tự nó đã đóng vai trò Repository + Unit of Work không? Vì sao Day07 không cần thêm IRepository<T> như các Day trước, dù logic nghiệp vụ (add, remove, find...) nhìn qua khá giống nhau?
- DbContext (AppDbContext) đóng vai trò Repository + Unit of Work  là đúng. Day07 không cần vì trong dbContext hiện có đủ các logic đó. Nếu sau này muốn ẩn dbcontext mới tạo ra interface bọc lại.