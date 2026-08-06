# (1) Deferred execution là gì, và bạn tìm thấy ví dụ nào trong chính code Day 04 này có thể bị ảnh hưởng bởi nó nếu không cẩn thận?
- Deferred execution là cơ chế tạm thời ngừng thực thi câu lệnh linq, chỉ khi có foreach, .toList(),... thì nó mới thực thi. 
-ví dụ trong đoạn .ToList(), nếu không có thì sẽ không thực thi được linq.

# (2) Vì sao GetHighestPaidEmployee() không thể dùng thẳng Max() mà phải dùng OrderByDescending().FirstOrDefault()?
- max() chỉ trả về giá trị highest chứ không trả về 1 Employee. Còn firstOrDefault sẽ lấy object đầu tiên nếu ko có trả null.
