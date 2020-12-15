using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class SeedData
    {
        private const int V = 1;

        // hàm này dùng để tạo dữ liệu trong lần build đầu tiên
        public static void createDataOnBuild(EFContext context)
        {
            // câu lệnh bên dưới dùng để ensure(tạo mới) data khi table chưa có data
            context.Database.EnsureCreated();

            /* kiểm tra đã có dữ liệu sẵn trong table chưa, nếu chưa thì tạo mới, nếu có rồi thì những lần
            build sau ko cần tạo thêm */
            if (context.Products.Any()) return;
            context.Products.AddRange(new List<Product>
            {
                new Product
                {
                    // IDPro là khoá chính nên trong DB code first no tự tạo cho mình
                   ProductName = "Mô hình Lego gấu mẹ",
                   ReleaseDate = DateTime.Parse("1989-2-12"),
                   Price=29000,
                   NewPrice=10900,
                   Describe="Được mô phỏng theo bộ phim ăn khách chú gấu tiber, kể về cuộc hành trình của chú gấu con tiber , trên quá trình giải cứu gấu mẹ khỏi đoàn thợ săn xấu xa.",
                   Number=100,
                   IDCategory=1,
                   ImagePath="Product1.jpg",
                   Image1="none",
                   Image2="none",
                   Image3="none",
                   IDSupplier=1,
                   isNew=false
                },
                 new Product
                {
                    // IDPro là khoá chính nên trong DB code first no tự tạo cho mình
                   ProductName = "Songoku",
                   ReleaseDate = DateTime.Parse("1982-2-12"),
                   Price=29000,
                   NewPrice=29000,
                   Describe="Hẳn tuổi thơ ai cũng biết đến bộ phim hoạt hình  7 Viên ngọc rồng, mô hình phỏng theo nhân vật chính songoku trong bộ phim hoạt hình này.",
                   Number=100,
                   IDCategory=2,
                   ImagePath="Product2.jpg",
                   Image1="none",
                   Image2="none",
                   Image3="none",
                   IDSupplier=1,
                   isNew=false
                },
                 new Product
                {
                    // IDPro là khoá chính nên trong DB code first no tự tạo cho mình
                   ProductName = "Spiderman",
                   ReleaseDate = DateTime.Parse("1981-2-12"),
                   Price=29000,
                   NewPrice=20500,
                   Describe="Được mô phỏng theo bộ phim ăn khách cảu điện ảnh marvel, người nhiện thu hút hàng triệu khán giả đến với rạp phim.",
                   Number=100,
                   IDCategory=3,
                   ImagePath="Product3.jpg",
                   Image1="Product3_1.jpg",
                   Image2="Product3_2.jpg",
                   Image3="none",
                   IDSupplier=1,
                   isNew=false
                },
                 new Product
                {
                    // IDPro là khoá chính nên trong DB code first no tự tạo cho mình
                   ProductName = "Hoshizoku",
                   ReleaseDate = DateTime.Parse("1985-2-12"),
                   Price=29000,
                   NewPrice=25000,
                   Describe="Mô hình đồ chơi phong cách anime nhật bản cực đẹp mắt.",
                   Number=100,
                   IDCategory=4,
                   ImagePath="Product4.jpg",
                   Image1="Product4_1.jpg",
                   Image2="Product4_2.jpg",
                   Image3="none",
                   IDSupplier=2,
                   isNew=false
                }
            });
            if (context.Categories.Any()) return;
            context.Categories.AddRange(new List<Category>
            {
                new Category
                {
                    CategoryName="HOẠT HÌNH TỔNG HỢP",
                    ImagePath="CartoonNetwork.jpg",
                    Describe="Tổng hợp các bộ phim hoạt hình trên thế giới.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="PHIM ĐIỆN ẢNH",
                    ImagePath="Movie.jpg",
                    Describe="Tập hợp các mô hình đến từ các phim điện ảnh nổi tiếng như holly wood, marvel, walt disney...vv",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="ANIME NHẬT BẢN",
                    ImagePath="Anime.jpg",
                    Describe="Anime là 1 phần không thể thiếu khi nhắc đến nhật bản, sau 10 năm phát triển, anime đã phát triển mạnh mẽ và được thế giới công nhận.",
                    Number=0,
                    ParentIDCategory=1
                },
                new Category
                {
                    CategoryName="ĐỒ CHƠI",
                    ImagePath="Lego.jpg",
                    Describe="Những mô hình đồ chơi tổng hợp từ nhiều thể loại, nhiều nguồn khác nhau.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="TRẺ EM",
                    ImagePath="Baby.jpg",
                    Describe="Những mô hình đồ chơi dành riêng cho trẻ em.",
                    Number=0,
                    ParentIDCategory=4
                },
                new Category
                {
                    CategoryName="NGƯỜI LỚN",
                    ImagePath="Adult.jpg",
                    Describe="Những mô hình đồ chơi dành riêng cho người lớn, thanh niên.",
                    Number=0,
                    ParentIDCategory=4
                },
                new Category
                {
                    CategoryName="TRUYỆN TRANH",
                    ImagePath="Manga.jpg",
                    Describe="Mô phỏng theo các bộ truyện tranh.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="MANGA",
                    ImagePath="Manga.jpg",
                    Describe="Truyện tranh nhật bản.",
                    Number=0,
                    ParentIDCategory=7
                },
                new Category
                {
                    CategoryName="MANHUA",
                    ImagePath="Anime.jpg",
                    Describe="Truyện tranh Trung Quốc.",
                    Number=0,
                    ParentIDCategory=7
                },
                new Category
                {
                    CategoryName="MANWA ",
                    ImagePath="Manwa.jpg",
                    Describe="Truyện tranh Hàn Quốc.",
                    Number=0,
                    ParentIDCategory=7
                },
                new Category
                {
                    CategoryName="TRANG PHỤC COSPLAY",
                    ImagePath="trangphuccosplay.jpg",
                    Describe="Đã từ lâu, cosplay đã là một hình thức nghệ thuật được yêu thích của các bạn trẻ.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="PHỤ KIỆN COSPLAY",
                    ImagePath="phukiencosplay.jpg",
                    Describe="Những mẫu phụ kiện có bán sẵn tại shop với giá cực hấp dẫn, đa dạng nhiều mẫu mã.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="GIÀY ANIME",
                    ImagePath="giayanime.jpg",
                    Describe="Xu hướng nhật bản anime giày phổ biến của năm 2020 trong Chức Năng Mới Lạ & Đặc Biệt.",
                    Number=0,
                    ParentIDCategory=12
                },
                new Category
                {
                    CategoryName="KIẾM GỖ - KỆ KIẾM",
                    ImagePath="kiemgokego.jpg",
                    Describe="Kiếm gỗ gồm bao kiếm và lưỡi kiếm bằng gỗ Dùng để trưng bày Sản phẩm đều có bán sẵn tại Shop Figure.",
                    Number=0,
                    ParentIDCategory=12
                },
                new Category
                {
                    CategoryName="NÓN - Ô DÙ - KẸP TÓC",
                    ImagePath="nonodukeptoc.jpg",
                    Describe="Mua Dù che mưa đội đầu 7 màu - Nón che nắng che mưa có gắn dù đội đầu giá tốt.",
                    Number=0,
                    ParentIDCategory=12
                },
                new Category
                {
                    CategoryName="PHI TIÊU - MẶT NẠ",
                    ImagePath="phitieumatna.jpg",
                    Describe="Mua Mặt Nạ Phi Tiêu của Shop Figure giá tốt. Mua hàng qua mạng uy tín, tiện lợi.",
                    Number=0,
                    ParentIDCategory=12
                },
                new Category
                {
                    CategoryName="BỘ FIGURE",
                    ImagePath="bofigure.jpg",
                    Describe="Sản phẩm nhập khẩu đảm bảo chất lượng. - Mô hình các nhân vật siêu anh hùng của Marvel cực ngầu và được làm với phong cách chibi.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="FIGURE",
                    ImagePath="figure.jpg",
                    Describe="Mang nhân vật bạn thích đến gần bạn hơn.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="MINI FIGURE",
                    ImagePath="minifigure.jpg",
                    Describe="Mua mini figure chính hãng giá tốt tháng 2020 tại Shop Figure.",
                    Number=0,
                    ParentIDCategory=0
                },
                new Category
                {
                    CategoryName="FIGMA & ACTION FIGURE",
                    ImagePath="figmaandactionfigure.jpg",
                    Describe="Trông tuyệt vời, tạo dáng dễ dàng. Dòng figma là một bộ sưu tập các nhân vật hành động bằng nhựa PVC có độ khớp nối cao nhưng vẫn đẹp mắt.",
                    Number=0,
                    ParentIDCategory=0
                }
                
            });
            if (context.Suppliers.Any()) return;
            context.Suppliers.AddRange(new List<Supplier>
            {
                new Supplier
                {
                    SupplierName="TAKISHOP",
                    Address="145 Hai Bà Trưng Q2 TPHCM",
                    Email="takivn@gmail.com",
                    Phone="0903221221"
                },
                 new Supplier
                {
                    SupplierName="JAPANGURE",
                    Address="offox 207, Paul street ,Ohio",
                    Email="Jkl021@gmail.com",
                    Phone="1373221221"
                },
                   new Supplier
                {
                    SupplierName="SHOPEE",
                    Address="210 Khắc Duật, Hà tây",
                    Email="shope@gmail.com",
                    Phone="1373221221"
                }
            });
            // sau khi tạo mới data thì SaveChanges lại
            context.SaveChanges();
        }
    }
}
