# cách chạy 
dotnet run
# validate trong Property vì sao?
vì khi set giá trị value ta sẽ validate nó trước khi set.
# id không set ngoài vì sao?
vì Id cần tăng tự động, nên sử dụng static để tăng nội bộ mỗi khi có 1 Employee được khởi tạo.
# vì sao trả IReadOnlyList thay vì List.
vì chỉ muốn đọc list mà không làm thêm chức năng gì. Chỉ có quyền đọc ko được thêm sửa xóa list. 