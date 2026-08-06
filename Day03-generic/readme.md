# (1) vì sao IRepository<T> cần là generic thay vì viết riêng IEmployeeRepository
- vì logic như add, remove, find,... được sử dụng ở nhiều entity, nên tạo ra kiểu T để tái sử dụng.

# (2) sự khác biệt giữa việc dùng Func<Employee, bool> truyền trực tiếp so với việc viết cứng nhiều method FindByHighSalary(), FindByHireYear() riêng lẻ
- Một method tổng quát nhận delegate làm tham số. Khi cần xử lý logic nào thì truyền lambda tương ứng logic đó vào method. Không cần tạo ra các hàm tránh phình code.
