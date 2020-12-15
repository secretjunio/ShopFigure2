+Thầy down src về , sau đó giải nén ra, vô thư mục appsetting.json đổi servername(Data Source) thành 
serverName của sql trên máy thầy , đổi cả user name và password thành của thầy, nếu không có username và pass thì 
thay bằng Integrated Security=True
+build src, chờ máy chạy xong, tạo xong database
-> vào sql server mở file SHOPFIGURE.sql chạy từng lệnh (địa chỉ tỉnh thành có thể chạy 1 lượt hết) để khởi tạo Admin, quyền hạn và 1 số trigger cơ bản
+Admin mặc định được gán với username=hollygraid ,password=123456 , với 2 quyền là admin và sale