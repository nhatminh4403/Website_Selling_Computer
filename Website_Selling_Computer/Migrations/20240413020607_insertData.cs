using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_Selling_Computer.Migrations
{
    /// <inheritdoc />
    public partial class insertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Enter data for the Manufacturers table
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerID", "ManufacturerName", "ContactInfo", "ManufacturerImage" },
                values: new object[,] {
         {1, "DELL", "https://www.dell.com/en-us/lp/contact-us","https://cdn-icons-png.flaticon.com/128/882/882726.png" },
         {2, "HP", "https://www.hp.com/us-en/contact-hp/shopping.html","https://cdn.iconscout.com/icon/premium/png-512-thumb/hp-2752159-2284976.png?f=webp&w=256" },
         {3, "LENOVO", "https://www.lenovo.com/us/en/contact/" ,"https://p4-ofp.static.pub/fes/cms/2022/11/14/h82es5y402b4rh1089sf86ay7n9sdl721044.png"},
         {4, "ACER", "https://www.acer.com/us-en/support/contact-acer","https://cdn-icons-png.flaticon.com/128/882/882748.png" },
         {5, "ASUS", "https://www.asus.com/us/support/callus/" ,"https://cdn.iconscout.com/icon/free/png-512/free-asus-226422.png?f=webp&w=256"},
         {6, "MSI","https://us.msi.com/about/contact-us","https://storage-asset.msi.com/frontend/imgs/logo.png"}
                });

            //Enter data for the ProductCategories table
            migrationBuilder.InsertData(
               table: "ProductCategories",
               columns: new[] { "CategoryID", "Description" },
               values: new object[,]
               {
         {1,"Laptop làm việc - học tập"},
         {2,"Laptop Gaming" },
         {3,"Laptop đồ họa" },
         {4,"Laptop mỏng nhẹ"}
               });

            //Enter data for the Product table
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductName", "CategoryID", "Description", "Price", "ManufacturerID", "MainImageUrl" },
                values: new object[,]
                {
         {1, "Dell Vostro 3530 V5I3465W1 Gray", 1, "Dell Vostro 3530 V5I3001W1 Gray là dòng laptop sinh viên sở hữu thiết kế mỏng nhẹ với nhiều tính năng nổi bật giúp bạn nâng cao thành tích học tập, tăng thêm trải nghiệm với các tựa game mình yêu thích. Đặc biệt, với trọng lượng chưa đến 2kg bạn hoàn toàn có thể cất gọn trong balo mang đi đến bất kỳ đâu.", 14690000.0, 1, "https://product.hstatic.net/200000722513/product/ava_323374780a104f079d493a9001f17921_1024x1024.png" },
         {2, "Dell Inspiron 3530 N3530I716W1 Silver", 1, "Tùy theo nhiều nhu cầu khác nhau mà có nhiều dòng sản phẩm laptop Dell khác nhau. Nếu bạn đang tìm một chiếc laptop phục vụ cho nhu cầu học tập và làm việc hằng ngày thì Dell Inspiron 3530 N3530I716W1 Silver sẽ là người bạn đồng hành cực tốt. cấu hình mạnh mẽ trên thiết kế đơn giản mang lại hiệu năng giải quyết mọi công việc mượt mà, nhanh chóng. ", 26990000.0, 1, "https://product.hstatic.net/200000722513/product/dell-inspiron-3530_99379d1e575240878fb8cad02396a1ce_1024x1024.png" },
         {3, "Dell XPS 13 Plus 71013325",4,"Dell XPS 13 Plus 71013325 là một chiếc laptop cao cấp dành cho những người dùng yêu thích sự sang trọng, hiệu năng mạnh mẽ và màn hình đẹp. Đây là một lựa chọn tuyệt vời cho những người thường xuyên di chuyển và cần một chiếc laptop để làm việc, giải trí và sáng tạo.",55490000.0,1,"https://cdn.tgdd.vn/Products/Images/44/314838/Slider/vi-vn-dell-xps-13-plus-9320-i5-71013325-slider-5.jpg"},
         {4, "Dell Latitude 3520 P108F001 70280538",1,"Là cái tên luôn nằm trong top đầu những thương hiệu laptop văn phòng uy tín nhất hiện, Dell nổi tiếng với những sản phẩm chất lượng, chỉnh chu tới từng chi tiết nhỏ nhất và Dell Latitude 3520 P108F001 70280538 cũng không phải ngoại lệ. Sở hữu thiết kế nhỏ gọn, sang trọng, mỏng nhẹ cùng hiệu năng cao vượt trội, đây luôn là lựa chọn hoàn hảo với những ai muốn tìm một chiếc laptop phục vụ cho công việc.", 24990000.0,1,"https://product.hstatic.net/200000722513/product/latitude-3520-p108f001-70280538-fix_83b4c85f06d145199d87d838dc9eca04_1024x1024.png"},

         {5,"HP Spectre x360 14a",4,"Laptop mỏng nhẹ, thời trang với màn hình OLED cảm ứng xoay 360 độ, hiệu năng mạnh mẽ",43990000.0,2,"https://m.media-amazon.com/images/I/7125ynjr8ZL._AC_SL1500_.jpg" },
         {6,"HP ZBook Studio G8",3,"Laptop đồ họa mạnh mẽ với card đồ họa NVIDIA RTX 3080 Ti, màn hình DreamColor 17 inch",99990000.0,2,"https://m.media-amazon.com/images/I/81xt8K8M+2L._AC_SL1500_.jpg" },
         {7,"HP OMEN 16 - b1115TX",2,"Laptop Gaming cấu hình cao, màn hình 144Hz",44990000.0,2,"https://in-media.apjonlinecdn.com/catalog/product/cache/74c1057f7991b4edb2bc7bdaa94de933/c/0/c07985275.png" },
         {8,"HP ProBook 450 G9",1,"Laptop mỏng nhẹ, bền bỉ với hiệu năng ổn định, phù hợp cho công việc và học tập",24990000.0,2,"https://kaas.hpcloud.hp.com/PROD/v2/renderbinary/6843701/5999582/com-win-nb-p-hp-probook-450-15-g9-ronin15-product-specification/com-nb-hp-probook-450-and-440-g9-product-image" },

         {9,"Lenovo ThinkPad X1 Carbon Gen 11 (14\" Intel)", 1, "Máy tính xách tay doanh nghiệp siêu nhẹ 14\" với hiệu năng mạnh mẽ, màn hình OLED tùy chọn và thời lượng pin dài.", 42990000.0, 3, "https://p4-ofp.static.pub/fes/cms/2023/02/10/7qjkk7h1a53t8jq5snivyzumxw040v193587.png"},
         {10,"Lenovo Legion 5 Pro (16\" AMD)",2,"Laptop chơi game mạnh mẽ với chip AMD Ryzen 7, card đồ họa NVIDIA GeForce RTX 3070 Ti, màn hình 16\" QHD 165Hz",43990000.0,3,"https://p3-ofp.static.pub/fes/cms/2023/02/14/kpdzuzvle3we5wjmqdm2bfhx0g4ag2178600.png" },
         {11,"Lenovo Yoga Slim 7 Pro",3,"Laptop mỏng nhẹ 14\" với màn hình OLED 2.8K, card đồ họa NVIDIA GeForce RTX 3050, phù hợp cho sáng tạo nội dung.",36990000.0,3,"https://images.fpt.shop/unsafe/fit-in/585x390/filters:quality(90):fill(white)/fptshop.com.vn/Uploads/Originals/2022/5/25/637890985840900515_lenovo-yoga-slim-7-pro-14ihu5-bac-1.jpg" },
         {12,"Lenovo IdeaPad Slim 5i Pro",4,"Laptop thời trang 14\" với màn hình OLED 2.8K, viền bezel siêu mỏng, thời lượng pin dài.",28990000.0,3,"https://p3-ofp.static.pub/fes/cms/2022/05/25/addxmfkfo5dfa2dvck0evgij7yrm2w327433.png" },

         {13,"Acer Aspire 5 A515-45-R5SB", 1, "Laptop học tập - văn phòng mạnh mẽ với Ryzen 5 5500U, RAM 8GB, SSD 512GB, màn hình Full HD 15.6 inch", 15990000.0, 4, "https://static-ecpa.acer.com/media/catalog/product/a/s/aspire5-a515-45-46-bl-sv-modelmain_1.png?optimize=high&bg-color=255,255,255&fit=bounds&height=500&width=500&canvas=500:500&format=jpeg"},
         {14,"Acer Nitro 5 AN515-45-R6EV", 2, "Laptop gaming cấu hình cao với Ryzen 5 5600H, RTX 3050 4GB, RAM 8GB, SSD 512GB, màn hình Full HD 15.6 inch 144Hz", 24990000.0, 4, "https://static-ecpa.acer.com/media/catalog/product/n/i/nitro5_an515-45_bl1_bk_modelmain_8.png?optimize=high&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},
         {15,"Acer Swift 3 SF314-511-57U5", 4, "Laptop mỏng nhẹ thời trang với Intel Core i5-1135G7, RAM 8GB, SSD 512GB, màn hình Full HD 14 inch IPS", 18490000.0, 4, "https://m.media-amazon.com/images/I/7107K3UUyGL._AC_SL1500_.jpg"},
         {16,"Acer ConceptD 3 CN315-72G-77U6", 3, "Laptop đồ họa chuyên nghiệp với Intel Core i7-11800H, RTX 3050 4GB, RAM 16GB, SSD 1TB, màn hình 4K UHD 15.6 inch", 41990000.0, 4, "https://static-ecpa.acer.com/media/catalog/product/c/o/conceptd-3-pro_cn315-72p_white_modelmain.png?optimize=high&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},

         {17,"MSI Modern 14 B12M-062VN", 1, "Laptop mỏng nhẹ, thời trang với viền màn hình siêu mỏng, hiệu năng mạnh mẽ", 18990000.0, 6, "https://storage-asset.msi.com/global/picture/image/feature/nb/Modern/Modern14C12X/kv-nb.png"},
         {18,"MSI Katana GF66 12UC-873VN", 2, "Laptop gaming giá rẻ, cấu hình mạnh mẽ, màn hình 144Hz", 20990000.0, 6, "https://storage-asset.msi.com/global/picture/image/feature/nb/GF/Katana-GF66-12U/kv-laptop-r.png"},
         {19,"MSI Creator Z16 A11UET-041VN", 3, "Laptop đồ họa chuyên nghiệp, màn hình OLED 4K, hiệu năng vượt trội", 64990000.0, 6, "https://asset.msi.com/resize/image/global/product/product_162035746357caaf684f1900109d3defc7efcd4dff.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {20,"MSI Prestige 14 Evo A11SCX-033VN", 4, "Laptop mỏng nhẹ, thời trang, hiệu năng mạnh mẽ", 24990000.0, 6, "https://m.media-amazon.com/images/I/81oeoSruyXL._AC_SL1500_.jpg"},

         {21,"ASUS Vivobook Pro 14 OLED M3401QA-KM015W", 4, "Laptop mỏng nhẹ màn hình OLED 14 inch, viền mỏng, cấu hình mạnh mẽ với AMD Ryzen 5 5600H, RAM 8GB, SSD 512GB, card đồ họa AMD Radeon™ Graphics.", 16490000.0, 5, "https://dlcdnwebimgs.asus.com/gain/a9903c82-cc86-409b-93c4-a4fdb33237ac/"},
         {22,"ASUS ROG Strix G15 G513RW HQ223W", 2, "Khác với những chiếc laptop cho sinh viên có cấu hình trung bình, laptop gaming ASUS ROG Strix G15 G513RW HQ223W sở hữu cấu hình AMD Ryzen 7-6800H 3.2GHz up to 4.7GHz, bộ nhớ RAM 16GB (2x8GB) DDR5, ổ cứng SSD 1TB cùng card đồ họa NVIDIA GeForce RTX 3070 Ti 8GB GDDR6 mạnh mẽ. Với cấu hình trên thì mọi tựa game AAA, phần mềm đồ họa gần như không thể làm khó được ASUS ROG Strix G15G513RW HQ223W", 57990000.0, 5, "https://product.hstatic.net/200000722513/product/ng-asus-rog-strix-g15-g513rw-hq223w-2_18919e1c87fb4e248cdd79f02374d0f6_6833742a53f149d68e1ee5f8f54e4983_1024x1024.jpg"},
         {23,"ASUS ZenBook Duo 14 UX482EA-KM053W", 3, "Laptop đồ họa với màn hình phụ ScreenPad Plus 12.6 inch, CPU Intel Core i7-1165G7, RAM 16GB, SSD 512GB, card đồ họa Intel Iris Xe Graphics.", 34990000.0, 5, "https://dlcdnwebimgs.asus.com/gain/7db3c178-1bd3-4692-ba64-7387277fa7b3/"},
         {24,"ASUS VivoBook Flip 14 TP470EA-EC006W", 1, "Laptop xoay gập 360 độ, màn hình cảm ứng, cấu hình tốt với Intel Core i3-1115G4, RAM 8GB, SSD 256GB.", 13490000.0, 5, "https://dlcdnwebimgs.asus.com/gain/3c2b1ef6-cbcb-4d15-b379-cc1b1c97f808/w800"}
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductID", "CPU", "RAM", "Storage", "Display", "GraphicsCard", "OperatingSystem", "BatteryLife", "Weight", "Warranty" },
                values: new object[,]
                {
         {1,"Intel Core i3-1305U (12M Cache, 3.70 GHz)",
         "8GB DDR4 3200MHz",
         "512GB SSD M.2 PCIe NVMe",
         "15.6\" FHD (1920x1080) Anti-glare, Non-Touch, 120Hz",
         "Intel UHD Graphics",
         "Windows 11 Home",
         "Up to 7 hours 12 minutes",
         "1.69kg",
         "12 tháng chính hãng Dell"
         },
         {
             2,
             "12th Gen Intel Core i7-1355U Processor",
             "16GB DDR4 3200MHz",
             "512GB SSD NVMe PCIe",
             "15.6-inch Full HD (1920 x 1080) 120Hz anti-glare",
             "NVIDIA GeForce MX550 2GB GDDR6",
             "Windows 11 Home + Office Student",
             "Up to 7 hours",
             "1.69kg",
             "1 year"
         },
         {
             3,
             "12th Gen Intel Core i5-1340P Processor (Up to 4.6 GHz) 12 Cores, 16 Threads",
             "16GB LPDDR5 6000MHz",
             "512GB PCIe NVMe SSD",
             "13.4-inch 3.5K OLED (3456 x 2160) touchscreen",
             "Intel Iris Xe Graphics",
             "Windows 11 Home + Microsoft Office Home and Student",
             "Up to 16 hours",
             "1.26kg",
             "1 year"
         },
         {
             4,
             "11th Gen Intel Core i7-1165G7 Processor ",
             "8GB DDR4 3200MHz",
             "256GB M.2 PCIe NVMe SSD",
             "15.6-inch Full HD (1920 x 1080) anti-glare, non-touch",
             "Intel Iris Xe Graphics",
             "Windows 11 Home",
             "Up to 8 hours",
             "1.79kg",
             "Typically 1 year standard warranty"
         },
         {
             5,
             "Up to 12th Gen Intel Core i7-1250U Processor",
             "Up to 16 GB DDR4-3733 MHz SDRAM",
             "Up to 1 TB PCIe NVMe M.2 SSD",
             "13.5-inch WUXGA+ (1920 x 1280)",
             "Intel Iris Xe Graphics",
             "Windows 11 Home",
             "Up to 17 hours",
             "1.33 kg",
             "Typically 1 year standard warranty"
         },
         {
             6,
             "Up to Intel Xeon W-3235 Processor",
             "Up to 32 GB DDR4-3200 MHz ECC RAM",
             "Up to 2 TB PCIe NVMe TLC SSD storage",
             "15.6-inch DreamColor UHD (3840 x 2160)",
             "Up to NVIDIA RTX A5000 16GB GDDR6",
             "Windows 11 Pro",
             "Up to 16 hours",
             "Starting at 2.0 kg",
             "Typically 1 year standard warranty"
         },
         {
             7,
             "AMD Ryzen 7 6800H Processor (3.2 GHz base clock, up to 4.7 GHz max boost clock)",
             "16 GB DDR4-3200 MHz RAM",
             "512GB PCIe NVMe M.2 SSD",
             "16.1-inch QHD (2560 x 1440)",
             "NVIDIA GeForce RTX 3060 Laptop GPU 6GB GDDR6",
             "Windows 11 Home",
             "Up to 9 hours",
             "2.37 kg",
             "Typically 1 year standard warranty"
         },
         {
             8,
             "Intel Core i5-1235U Processor",
             "8 GB DDR4-3200 MHz RAM",
             "512GB PCIe NVMe M.2 SSD",
             "15.6-inch FHD (1920 x 1080) IPS anti-glare display",
             "Intel UHD Graphics",
             "Windows 11 Pro",
             "Up to 8 hours",
             "1.74 kg",
             "1 năm tiêu chuẩn"
         },
         {
             9,
             "Up to 12th Gen Intel Core i7 Processors",
             "Up to 32GB LPDDR5",
             "Up to 2TB PCIe Gen 4 SSD",
             "14-inch 2.8K (2880 x 1800)",
             "Intel Iris Xe Graphics",
             "Windows 11 Pro",
             "Up to 19.5 hours",
             "1.27kg",
             "Typically 1 year standard warranty"
         },
         {
             10,
             "Up to AMD Ryzen 7 6800H Processor",
             "Up to 32GB DDR5-4800 MHz RAM",
             "Up to 2TB PCIe NVMe M.2 SSD",
             "16-inch QHD (2560 x 1440) IPS anti-glare display with up to 240Hz refresh rate",
             "Up to NVIDIA GeForce RTX 3070 Laptop GPU 8GB GDDR6",
             "Windows 11 Home or Windows 11 Pro",
             "Up to 7 hours",
             "2.47kg",
             "Typically 1 year standard warranty"
         },
         {
             11,
             "Up to 12th Gen Intel Core i7 Processors",
             "Up to 16GB LPDDR5",
             "Up to 1TB PCIe NVMe SSD",
             "14-inch WQXGA (2560 x 1600) IPS touchscreen or OLED display",
             "Intel Iris Xe Graphics or NVIDIA GeForce RTX 3050 Laptop GPU",
             "Windows 11 Home",
             "Up to 18 hours ",
             "1.3kg",
             "Typically 1 year standard warranty"
         },
         {
             12,
             "Up to 12th Gen Intel Core i7 Processors or AMD Ryzen 7 processors",
             "Up to 16GB DDR4",
             "Up to 1TB PCIe NVMe SSD",
             "16-inch or 14-inch FHD (1920 x 1080) IPS anti-glare display",
             "Intel Iris Xe Graphics or NVIDIA GeForce MX450",
             "Windows 11 Home",
             "Up to 15 hours ",
             "1.7kg",
             "Typically 1 year standard warranty"
         },
         { 13, "Up to 11th Gen Intel Core i5 Processor", "Up to 8GB DDR4", "Up to 512GB PCIe NVMe SSD", "15.6-inch FHD (1920 x 1080) IPS display", "Intel Iris Xe Graphics", "Windows 11 Home", "Up to 8 hours (mobilemark 2018 benchmark, may vary with use)", "1.8kg (approximate)", "Typically 1 year standard warranty" },
         { 14, "Up to 11th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 1TB PCIe NVMe SSD", "15.6-inch FHD (1920 x 1080) IPS display with 144Hz refresh rate (optional)", "Up to NVIDIA GeForce RTX 3050 Ti Laptop GPU", "Windows 11 Home", "Up to 8 hours (may vary with use)", "2.3kg (approximate)", "Typically 1 year standard warranty" },
         { 15, "Up to 11th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 512GB PCIe NVMe SSD", "14-inch FHD (1920 x 1080) IPS display", "Intel Iris Xe Graphics", "Windows 11 Home", "Up to 17 hours (MobileMark 2018 benchmark, may vary with use)", "1.2kg (approximate)", "Typically 1 year standard warranty" },
         { 16, "Up to 11th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 1TB PCIe NVMe SSD", "15.6-inch QHD (2560 x 1440) IPS display with optional touch", "Up to NVIDIA GeForce RTX 3060 Laptop GPU", "Windows 11 Home or Windows 11 Pro", "Up to 8 hours (may vary with use)", "2.1kg (approximate)", "Typically 1 year standard warranty" },
         { 17, "Up to 12th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 1TB PCIe NVMe SSD", "14-inch FHD (1920 x 1080) IPS anti-glare display", "Intel Iris Xe Graphics", "Windows 11 Home", "Up to 10 hours (may vary with use)", "1.3kg (approximate)", "Typically 1 year standard warranty" },
         { 18, "Up to 12th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 1TB PCIe NVMe SSD", "15.6-inch FHD (1920 x 1080) IPS display with 144Hz refresh rate", "Up to NVIDIA GeForce RTX 3050 Ti Laptop GPU", "Windows 11 Home", "Up to 4 hours (gaming, may vary with use)", "2.2kg (approximate)", "Typically 1 year standard warranty" },
         { 19, "Up to 11th Gen Intel Core i7 Processor", "Up to 32GB DDR4", "Up to 2TB PCIe NVMe SSD", "16-inch QHD+ (3840 x 2400) IPS True Pixel touch display", "Up to NVIDIA GeForce RTX 3060 Laptop GPU", "Windows 11 Pro", "Up to 8 hours (may vary with use)", "2.2kg (approximate)", "Typically 1 year standard warranty" },
         { 20, "Up to 12th Gen Intel Core i7 Processor", "Up to 16GB LPDDR4X", "Up to 1TB PCIe NVMe SSD", "14-inch WQHD+ (2560 x 1600) OLED touch display", "Up to NVIDIA GeForce RTX 3050 Laptop GPU", "Windows 11 Home", "Up to 10 hours (may vary with use)", "1.6kg (approximate)", "Typically 1 year standard warranty" },
         { 21, "Up to AMD Ryzen 7 6800H Processor", "Up to 16GB DDR4", "Up to 1TB PCIe NVMe SSD", "14-inch 2.8K (2880 x 1800) OLED touchscreen display", "Up to NVIDIA GeForce RTX 3050 Laptop GPU", "Windows 11 Home", "Up to 8 hours (may vary with use)", "1.6kg (approximate)", "Typically 1 year standard warranty" },
         { 22, "AMD Ryzen 7 6800H Processor", "16GB DDR5", "1TB M.2 NVMe™ PCIe® 4.0 SSD", "15.6-inch FHD (1920 x 1080) IPS anti-glare display with up to 300Hz refresh rate", "NVIDIA GeForce RTX 3070 Ti Laptop GPU 8GB GDDR6", "Windows 11 Home", "Up to 7 hours (MobileMark 2018 benchmark, may vary with use)", "2.3kg (approximate)", "Typically 1 year standard warranty" },
         { 23, "Up to 12th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 1TB PCIe NVMe SSD", "14-inch FHD (1920 x 1080) OLED main display + 12.6-inch touchscreen secondary display", "Intel Iris Xe Graphics", "Windows 11 Pro", "Up to 17 hours (MobileMark 2018 benchmark, may vary with use)", "1.7kg (approximate)", "Typically 1 year standard warranty" },
         { 24, "Up to 11th Gen Intel Core i7 Processor", "Up to 16GB DDR4", "Up to 512GB PCIe NVMe SSD", "14-inch FHD (1920 x 1080) touchscreen display", "Intel Iris Xe Graphics", "Windows 11 Home", "Up to 22 hours (may vary with use)", "1.5kg (approximate)", "Typically 1 year standard warranty" }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductID", "QuantityInStock", "ReorderLevel" },
                values: new object[,]
                {
         {1,20,20 },
         {2,20,20 },
         {3,20,20 },
         {4,20,20 },
         {5,20,20 },
         {6,20,20 },
         {7,20,20 },
         {8,20,20 },
         {9,20,20 },
         {10,20,20 },
         {11,20,20 },
         {12,20,20 },
         {13,20,20 },
         {14,20,20 },
         {15,20,20 },
         {16,20,20 },
         {17,20,20 },
         {18,20,20 },
         {19,20,20 },
         {20,20,20 },
         {21,20,20 },
         {22,20,20 },
         {23,20,20 },
         {24,20,20 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageID", "ProductID", "ImageUrl" },
                values: new object[,]
                {
         {1,1,"https://product.hstatic.net/200000722513/product/ava_323374780a104f079d493a9001f17921_1024x1024.png" },
         {2,1,"https://product.hstatic.net/200000722513/product/gray-aluminum-fpr-gallery-1_eb897d0b3d224bc1a20aba564da865f6_1024x1024_c6e12b0606404c6da8065e1fdd784338_1024x1024.png" },
         {3,1,"https://product.hstatic.net/200000722513/product/gray-aluminum-fpr-gallery-2_bdaaa90de42c4b13b75a3984747eaa98_1024x1024_bd9a0fb9274c4d41ad6cf99af6378a8a_1024x1024.png" },
         {4,1,"https://product.hstatic.net/200000722513/product/gray-aluminum-fpr-gallery-4_4272458c77214a0a8027c7656e4110d0_1024x1024_1003ad4dd6bf4f5bb4c8f268cde7156b_1024x1024.png" },
         {5,1,"https://product.hstatic.net/200000722513/product/gray-aluminum-fpr-gallery-5_87b07f58af8d420fb6cbdf2cd8db1ae1_1024x1024_2f75baedb3c046f0b7cf64f3ab4890b9_1024x1024.png" },
         {6,2,"https://product.hstatic.net/200000722513/product/notebook-inspiron-15-3530-nt-plastic-usbc-silver-gallery-4_4785a3e4d15e4befb1ab100a6d81c42c_1024x1024.jpg" },
         {7,2,"https://product.hstatic.net/200000722513/product/notebook-inspiron-15-3530-nt-plastic-silver-gallery-5_92764be610c24584b943c2b9ead19e07_1024x1024.jpg" },
         {8,2,"https://product.hstatic.net/200000722513/product/notebook-inspiron-15-3530-nt-plastic-silver-gallery-3_98d57f5c0e0740c38a7e87656a448399_1024x1024.jpg"},
         {9,2,"https://product.hstatic.net/200000722513/product/notebook-inspiron-15-3530-nt-plastic-silver-gallery-10_2c9ef15843da44a29d1c013c1a9fabce_1024x1024.jpg"},
         {10,2,"https://product.hstatic.net/200000722513/product/notebook-inspiron-15-3530-nt-plastic-usbc-data-silver-gallery-8_9aea627f238b482bbaf27836edc48207_1024x1024.jpg"},
         {11,3,"https://anphat.com.vn/media/product/45591_laptop_dell_xps_9320_13_plus_71013325_anphatpc6.jpg"},
         {12,3,"https://anphat.com.vn/media/product/45591_laptop_dell_xps_9320_13_plus_71013325__6_.jpg"},
         {13,3,"https://anphat.com.vn/media/product/45591_laptop_dell_xps_9320_13_plus_71013325__5_.jpg"},
         {14,3,"https://anphat.com.vn/media/product/45591_laptop_dell_xps_9320_13_plus_71013325__4_.jpg"},
         {15,3,"https://anphat.com.vn/media/product/45591_laptop_dell_xps_9320_13_plus_71013325__3_.jpg"},
         {16,4,"https://product.hstatic.net/200000722513/product/pherals_latop_latitude_3520_gallery_5_ce328dd2d885438db9a3b46fff39cc48_211cb71c3c384326b0b8ac43943f0b89_1024x1024.png"},
         {17,4,"https://product.hstatic.net/200000722513/product/pherals_latop_latitude_3520_gallery_4_6dd20f9ad6dc458e88a5716967e2cf98_c897e822f9784612b8d05d0c09055c7c_1024x1024.png"},
         {18,4,"https://product.hstatic.net/200000722513/product/pherals_latop_latitude_3520_gallery_6_b7031c43f13749deaba8e5c24ea9df6e_49fa4efa91ca49c9b9585f1437a7c109_1024x1024.png"},
         {19,4,"https://product.hstatic.net/200000722513/product/pherals_latop_latitude_3520_gallery_7_40ed5e9d4d4d4893a983c8453efc02c8_9582e5412b6e417dbdecf0bc3fdef6b4_1024x1024.png"},
         {20,4,"https://product.hstatic.net/200000722513/product/pherals_latop_latitude_3520_gallery_1_d106f7b8a4704936ad0a273fea72c191_5d8e853dc9934cf8abddad9953ace90a_1024x1024.png"},
         {21,5,"https://m.media-amazon.com/images/I/61AWzvG9pXL._AC_SL1222_.jpg"},
         {22,5,"https://m.media-amazon.com/images/I/617R01fX86L._AC_SL1001_.jpg"},
         {23,5,"https://m.media-amazon.com/images/I/61n3dXx3WwL._AC_SL1129_.jpg"},
         {24,5,"https://m.media-amazon.com/images/I/61zTIMXwc1L._AC_SL1092_.jpg"},
         {25,5,"https://m.media-amazon.com/images/I/51rXmwhbrTL._AC_SL1125_.jpg"},
         {26,6,"https://m.media-amazon.com/images/I/81fjGbw5guL._AC_SL1500_.jpg"},
         {27,6,"https://m.media-amazon.com/images/I/61gH0JKiwiL._AC_SL1500_.jpg"},
         {28,6,"https://m.media-amazon.com/images/I/51lp976IvfL._AC_SL1500_.jpg"},
         {29,6,"https://m.media-amazon.com/images/I/51PE36KfIzL._AC_SL1500_.jpg"},
         {30,6,"https://m.media-amazon.com/images/I/51StEcXo5-L._AC_.jpg"},
         {31,7,"https://m.media-amazon.com/images/I/41DKX5fbGcL._AC_SL1131_.jpg"},
         {32,7,"https://m.media-amazon.com/images/I/51Tvf9nzelL._AC_SL1500_.jpg"},
         {33,7,"https://m.media-amazon.com/images/I/51g7lRPHkYL._AC_SL1500_.jpg"},
         {34,7,"https://m.media-amazon.com/images/I/81XhwTLbkZL._AC_SL1500_.jpg"},
         {35,7,"https://m.media-amazon.com/images/I/81sXPeljUeL._AC_SL1500_.jpg"},
         {36,8,"https://m.media-amazon.com/images/I/61q-8E07keL._AC_SL1500_.jpg"},
         {37,8,"https://m.media-amazon.com/images/I/41LjB-wEuXL._AC_SL1500_.jpg"},
         {38,8,"https://m.media-amazon.com/images/I/519VLam7-0L._AC_SL1500_.jpg"},
         {39,8,"https://m.media-amazon.com/images/I/51hOcEJFa6L._AC_.jpg"},
         {40,8,"https://m.media-amazon.com/images/I/41xZh0FRYyL._AC_SL1500_.jpg"},
         {41,9,"https://m.media-amazon.com/images/I/51YHkOjq1TL._AC_.jpg"},
         {42,9,"https://m.media-amazon.com/images/I/41g+ZCUkixL._AC_.jpg"},
         {43,9,"https://m.media-amazon.com/images/I/41fybualBhL._AC_.jpg"},
         {44,9,"https://m.media-amazon.com/images/I/21Kp0tiU7oL._AC_.jpg"},
         {45,9,"https://m.media-amazon.com/images/I/21ZygnL3QCL._AC_.jpg"},
         {46,10,"https://m.media-amazon.com/images/I/6174k7fpNEL._AC_SL1500_.jpg"},
         {47,10,"https://m.media-amazon.com/images/I/61xcB0hdONL._AC_SL1500_.jpg"},
         {48,10,"https://m.media-amazon.com/images/I/61dH7clMI6L._AC_SL1500_.jpg"},
         {49,10,"https://m.media-amazon.com/images/I/513innOo2RL._AC_SL1500_.jpg"},
         {50,10,"https://m.media-amazon.com/images/I/51Cp7-iQXzL._AC_SL1010_.jpg"},
         {51,11,"https://p2-ofp.static.pub/fes/cms/2021/07/27/siuu3xl2npdoh88mr471epmhybrsww596708.png"},
         {52,11,"https://p2-ofp.static.pub/fes/cms/2021/07/27/qn4g7f5gbo27fvkpvzzuq9bp1h8rxa128143.png"},
         {53,11,"https://p1-ofp.static.pub/fes/cms/2021/07/27/xsjox7qpupua3ovsl3owf9j1ovgx1r029039.png"},
         {54,11,"https://p1-ofp.static.pub/fes/cms/2021/07/27/3gdgeqesg6yclqo9whlf1pn9ykbbum082325.png"},
         {55,11,"https://p3-ofp.static.pub/fes/cms/2021/07/27/47y4byipyferd2o0ttul8s91vyy5m7983891.png"},
         {56,12,"https://p1-ofp.static.pub/fes/cms/2022/07/04/g3it6b78198toarzyj8qjwsny68rcf523499.jpg"},
         {57,12,"https://p1-ofp.static.pub/fes/cms/2022/07/04/unvoo4m3t73uta72ftha283cywey74853619.jpg"},
         {58,12,"https://p1-ofp.static.pub/fes/cms/2022/07/04/m2urc4zto2fygd9wcikzt0g0jjvzk5439557.jpg"},
         {59,12,"https://p1-ofp.static.pub/fes/cms/2022/07/04/2ftrnkl4m412hjp4jc4roesmora4yk492876.jpg"},
         {60,12,"https://p1-ofp.static.pub/fes/cms/2022/07/04/gl5u7f8w02og8gbmextwkkzi1dakn6998942.jpg"},
         {61,13,"https://m.media-amazon.com/images/I/71esri4NxrL._AC_SL1500_.jpg"},
         {62,13,"https://m.media-amazon.com/images/I/71j9k+5Yz1L._AC_SL1500_.jpg"},
         {63,13,"https://m.media-amazon.com/images/I/71mGg-paOdL._AC_SL1500_.jpg"},
         {64,13,"https://m.media-amazon.com/images/I/615Q24At4cL._AC_SL1500_.jpg"},
         {65,13,"https://m.media-amazon.com/images/I/719k37ONwoL._AC_SL1500_.jpg"},
         {66,14,"https://m.media-amazon.com/images/I/61M-ls+sUBL._AC_SL1430_.jpg"},
         {67,14,"https://m.media-amazon.com/images/I/51xyCc4IBsL._AC_SL1430_.jpg"},
         {68,14,"https://m.media-amazon.com/images/I/51yCzyoIpdL._AC_SL1430_.jpg"},
         {69,14,"https://m.media-amazon.com/images/I/412hz0oVnOL._AC_SL1430_.jpg"},
         {70,14,"https://m.media-amazon.com/images/I/61ChcCrW3JL._AC_SL1237_.jpg"},
         {71,15,"https://m.media-amazon.com/images/I/61Mz6q359lS._AC_SL1000_.jpg"},
         {72,15,"https://m.media-amazon.com/images/I/61-GwBv2WzS._AC_SL1000_.jpg"},
         {73,15,"https://m.media-amazon.com/images/I/71HaInnZRjS._AC_SL1000_.jpg"},
         {74,15,"https://m.media-amazon.com/images/I/71V5BjSYNoL._AC_SL1500_.jpg"},
         {75,15,"https://m.media-amazon.com/images/I/71OOr0U99TL._AC_SL1500_.jpg"},
         {76,16,"https://static2-ecemea.acer.com/media/catalog/product/_/_/________c__conceptd-3_cn315-72-72g_white_gallery_02_1_nx.c5yek.001.png?quality=80&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},
         {77,16,"https://static2-ecemea.acer.com/media/catalog/product/_/_/________c__conceptd-3_cn315-72-72g_white_gallery_03_1_nx.c5yek.001.png?quality=80&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},
         {78,16,"https://static2-ecemea.acer.com/media/catalog/product/_/_/________c__conceptd-3_cn315-72-72g_white_gallery_04_1_nx.c5yek.001.png?quality=80&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},
         {79,16,"https://static2-ecemea.acer.com/media/catalog/product/_/_/________c__conceptd-3_cn315-72-72g_white_gallery_06_1_nx.c5yek.001.png?quality=80&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},
         {80,16,"https://static2-ecemea.acer.com/media/catalog/product/_/_/________c__conceptd-3_cn315-72-72g_white_gallery_07_1_nx.c5yek.001.png?quality=80&bg-color=255,255,255&fit=bounds&height=&width=&canvas=:&format=jpeg"},
         {81,17,"https://asset.msi.com/resize/image/global/product/product_1669882648d8be33b846e1a7fe4b32c4a0e48e1d31.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {82,17,"https://asset.msi.com/resize/image/global/product/product_1669882651fb16c3c42d4c4e1e6a613b24c60fb619.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {83,17,"https://asset.msi.com/resize/image/global/product/product_168974719493480c4e090deebe413ef445cef0ec7d.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {84,17,"https://asset.msi.com/resize/image/global/product/product_1669882653cd9cd3fb2e3238652a4a7b253bd1a68a.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {85,17,"https://asset.msi.com/resize/image/global/product/product_166988264619427a1f367593e6b07dac35b82e8b73.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {86,18,"https://asset.msi.com/resize/image/global/product/product_16429908194d117a3ebc8e27cfc1e912db7caf51b2.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {87,18,"https://asset.msi.com/resize/image/global/product/product_16358186360617f4927bff7d74773c651c85d88a8e.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {88,18,"https://asset.msi.com/resize/image/global/product/product_163600344089c81a2349e9d1a2f0202ea6b59515c9.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {89,18,"https://asset.msi.com/resize/image/global/product/product_16358186382badb4beda5bf72702b275cf2028dd5e.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {90,18,"https://asset.msi.com/resize/image/global/product/product_1636003440d61b526135cdd7f45957f70fec2db27d.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {91,19,"https://asset.msi.com/resize/image/global/product/product_16897361372aaf53811446b88c1b3ed5716a0cab64.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {92,19,"https://asset.msi.com/resize/image/global/product/product_16203574632c32e32563b23c600e4c5dc6546a1d8a.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {93,19,"https://asset.msi.com/resize/image/global/product/product_16203574659e0234a56ed615226a1094113c2c0b75.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {94,19,"https://asset.msi.com/resize/image/global/product/product_16203574653df735b641d892e6da70387cb1ed8a34.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {95,19,"https://asset.msi.com/resize/image/global/product/product_162035746700c83d1bba3f6b900fca362ef2da8681.png62405b38c58fe0f07fcef2367d8a9ba1/1024.png"},
         {96,20,"https://asset.msi.com/resize/image/global/product/product_1689746501357d19cd6f2b842a6c3af94f4bffd465.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {97,20,"https://asset.msi.com/resize/image/global/product/product_9_20200827164603_5f4772cbdd6c0.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {98,20,"https://asset.msi.com/resize/image/global/product/product_0_20200827164613_5f4772d53c80a.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {99,20,"https://asset.msi.com/resize/image/global/product/product_16212318073d4a976906cbb7a11525f547195f3381.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {100,20,"https://asset.msi.com/resize/image/global/product/product_1621231807f9fd3655cb7ae998481c71273238f58a.png62405b38c58fe0f07fcef2367d8a9ba1/600.png"},
         {101,21,"https://laptopworld.vn/media/product/10456_asus_vivobook_pro_14_oled_b___c__3.jpg"},
         {102,21,"https://laptopworld.vn/media/product/10456_asus_vivobook_pro_14_oled_b___c__4.jpg"},
         {103,21,"https://laptopworld.vn/media/product/10456_asus_vivobook_pro_14_oled_b___c__5.jpg"},
         {104,21,"https://laptopworld.vn/media/product/10456_asus_vivobook_pro_14_oled_b___c__6.jpg"},
         {105,21,"https://laptopworld.vn/media/product/10456_"},
         {106,22,"https://product.hstatic.net/200000722513/product/ng-asus-rog-strix-g15-g513rw-hq223w-1_6c1370feaf5b40db9c651d16b86839b6_922e526f2766460b9e42b49d73ffd2f5_1024x1024.jpg"},
         {107,22,"https://product.hstatic.net/200000722513/product/ng-asus-rog-strix-g15-g513rw-hq223w-2_18919e1c87fb4e248cdd79f02374d0f6_6833742a53f149d68e1ee5f8f54e4983_1024x1024.jpg"},
         {108,22,"https://product.hstatic.net/200000722513/product/ng-asus-rog-strix-g15-g513rw-hq223w-3_0917dc07b70f498fa3a5ffb1c5a1410d_bece7ff147c641aea0b4b981ddf5c76f_1024x1024.jpg"},
         {109,22,"https://product.hstatic.net/200000722513/product/ng-asus-rog-strix-g15-g513rw-hq223w-4_55094bbc28a9450ea295fd441381e4a1_2fe6cd9203a34253abe90a19431cb10e_1024x1024.jpg"},
         {110,22,"https://product.hstatic.net/200000722513/product/ng-asus-rog-strix-g15-g513rw-hq223w-5_86c95cea85b14eb6848cc4a24081bee1_9f099c5647f747eeb192058d4ce9429a_1024x1024.jpg"},
         {111,23,"https://dlcdnwebimgs.asus.com/gain/bb27b53c-c079-44b9-850e-fcd8743dc742/w800"},
         {112,23,"https://dlcdnwebimgs.asus.com/gain/18702625-5d29-4496-83a4-3d01c66ef46b/w800"},
         {113,23,"https://dlcdnwebimgs.asus.com/gain/81527ede-fb2a-4bc2-8814-9df956a1183a/w800"},
         {114,23,"https://dlcdnwebimgs.asus.com/gain/58961615-52a7-443c-b21a-6b7a6cd1800f/w800"},
         {115,23,"https://dlcdnwebimgs.asus.com/gain/3d2980b4-3a32-46b9-a3e6-af615b097667/w800"},
         {116,24,"https://dlcdnwebimgs.asus.com/gain/24dba4c3-96af-40f0-a9a3-a3e17e17b026/w800"},
         {117,24,"https://dlcdnwebimgs.asus.com/gain/0825e059-c421-4f63-98bb-485bfbc31050/w800"},
         {118,24,"https://dlcdnwebimgs.asus.com/gain/3c2b1ef6-cbcb-4d15-b379-cc1b1c97f808/w800"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
