using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_Selling_Computer.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Enter data for the Manufacturers table
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerID", "ManufacturerName", "ContactInfo" },
                values: new object[,] {
                    {1, "DELL", "https://www.dell.com/en-us/lp/contact-us" },
                    {2, "HP", "https://www.hp.com/us-en/contact-hp/shopping.html" },
                    {3, "LENOVO", "https://www.lenovo.com/us/en/contact/" },
                    {4, "ACER", "https://www.acer.com/us-en/support/contact-acer" },
                    {5, "ASUS", "https://www.asus.com/us/support/callus/" },
                    {6, "MSI","https://us.msi.com/about/contact-us"}
                });

            //Enter data for the ProductCategories table
            migrationBuilder.InsertData(
               table: "ProductCategories",
               columns: new[] {"CategoryID","Description" },
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
                columns: new[] {"ProductID", "ProductName", "CategoryID", "Description", "Price", "ManufacturerID", "MainImage" },
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

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
