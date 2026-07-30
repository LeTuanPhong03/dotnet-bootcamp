# cách chạy 
dotnet run

# abstract class và interface

Abstract class và Interface (gợi ý):

- Abstract class: là lớp không thể khởi tạo trực tiếp, có thể chứa cả phương thức đã triển khai và phương thức trừu tượng (không có thân). Dùng khi muốn chia sẻ code giữa các lớp liên quan.
- Interface: chỉ khai báo chữ ký phương thức/properties (trừ các default implementation trong C# mới), lớp implement interface phải định nghĩa tất cả. Dùng để mô tả hành vi và hỗ trợ đa kế thừa kiểu.
- Khác biệt chính: abstract class có trạng thái và triển khai một phần, interface tập trung vào hợp đồng; một lớp chỉ kế thừa một abstract class nhưng có thể implement nhiều interface.

Ví dụ ngắn (C#):

abstract class Animal { public abstract void Speak(); public void Eat() { /*...*/ } }
interface IFly { void Fly(); }
class Bird : Animal, IFly { public override void Speak() { } public void Fly() { } }

# vì sao Employee phải là abstract class, vì sao ISalaryCalculator tách riêng thành interface.
-Employee nó là lớp cha có các thuộc tính chung dùng cho các lớp như fulltime, partTime,...
- ISalaryCalculator tách riêng vì không chỉ mỗi Employee dùng nó. Có thể chỗ khác tính lương sẽ dùng nó. Còn nếu đưa vào abtract class thì chỗ khác dùng sẽ không phù hợp.