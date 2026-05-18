using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PICMate.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PhotographerId = table.Column<int>(type: "integer", nullable: false),
                    PhotographerName = table.Column<string>(type: "text", nullable: false),
                    PhotographerAvatar = table.Column<string>(type: "text", nullable: false),
                    Service = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemoAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Redirect = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disputes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    Reporter = table.Column<string>(type: "text", nullable: false),
                    ReporterAvatar = table.Column<string>(type: "text", nullable: false),
                    Against = table.Column<string>(type: "text", nullable: false),
                    AgainstAvatar = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disputes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoritePhotographers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhotographerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePhotographers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Popular = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    LastMessage = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    Unread = table.Column<int>(type: "integer", nullable: false),
                    Online = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    CoverPhoto = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    ReviewCount = table.Column<int>(type: "integer", nullable: false),
                    IsOnline = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    InstantBooking = table.Column<bool>(type: "boolean", nullable: false),
                    HourlyPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PerPhotoPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TiktokPackagePrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    BeforeImage = table.Column<string>(type: "text", nullable: false),
                    Downloads = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Emoji = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    JoinDate = table.Column<string>(type: "text", nullable: false),
                    TotalBookings = table.Column<int>(type: "integer", nullable: false),
                    TotalSpent = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MembershipPlanId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipFeatures_MembershipPlans_MembershipPlanId",
                        column: x => x.MembershipPlanId,
                        principalTable: "MembershipPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotographerPortfolioImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhotographerId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerPortfolioImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotographerPortfolioImages_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotographerReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhotographerId = table.Column<int>(type: "integer", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotographerReviews_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotographerStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhotographerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerStyles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotographerStyles_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Icon", "Text", "Time", "Type" },
                values: new object[,]
                {
                    { 1, "👤", "Võ Thị E đã đăng ký tài khoản mới", "5 phút trước", "new_user" },
                    { 2, "📦", "Đơn hàng BK-20251225-010 được tạo mới", "12 phút trước", "booking" },
                    { 3, "⚠️", "Khiếu nại mới từ Trần Thị B", "3 giờ trước", "dispute" }
                });

            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "Id", "Color", "Key", "Label" },
                values: new object[,]
                {
                    { 1, "warning", "pending", "Chờ xác nhận" },
                    { 2, "info", "confirmed", "Đã nhận" },
                    { 3, "info", "in_progress", "Đang thực hiện" },
                    { 4, "success", "completed", "Hoàn thành" },
                    { 5, "danger", "cancelled", "Đã hủy" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Date", "Location", "Note", "PhotographerAvatar", "PhotographerId", "PhotographerName", "Service", "Status", "Time", "Total" },
                values: new object[,]
                {
                    { "BK-20251215-001", "2025-12-20", "Cafe The Coffee House, Quận 1", "Concept: Korean casual", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", 1, "Đào Nguyên Trọng", "Chụp ảnh sống ảo", "completed", "14:00", 200000m },
                    { "BK-20251218-002", "2025-12-25", "Phố đi bộ Nguyễn Huệ", "Content review cafe + ăn vặt", "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face", 3, "Bảo Vũ", "Quay TikTok", "confirmed", "09:00", 400000m }
                });

            migrationBuilder.InsertData(
                table: "DemoAccounts",
                columns: new[] { "Id", "Avatar", "Email", "Name", "Password", "Redirect", "Role" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=100&h=100&fit=crop&crop=face", "khach@picmate.vn", "Nguyễn Văn Khách", "123456", "/dashboard", "customer" },
                    { 2, "/Trong.jpg", "photographer@picmate.vn", "Đào Nguyên Trọng", "123456", "/dashboard/photographer", "photographer" },
                    { 3, "", "admin@picmate.vn", "Admin PICMate", "admin123", "/admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Disputes",
                columns: new[] { "Id", "Against", "AgainstAvatar", "Amount", "Date", "OrderId", "Priority", "Reason", "Reporter", "ReporterAvatar", "Status" },
                values: new object[,]
                {
                    { "DP-001", "Đào Nguyên Trọng", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", 200000m, "2025-12-18", "BK-20251215-001", "high", "Thợ chụp đến muộn 30 phút", "Nguyễn Văn A", "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=100&h=100&fit=crop&crop=face", "pending" },
                    { "DP-002", "Bảo Vũ", "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face", 400000m, "2025-12-20", "BK-20251218-002", "urgent", "Yêu cầu hoàn tiền do thợ hủy đơn", "Trần Thị B", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", "pending" }
                });

            migrationBuilder.InsertData(
                table: "FavoritePhotographers",
                columns: new[] { "Id", "PhotographerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "MembershipPlans",
                columns: new[] { "Id", "Name", "Popular", "Price" },
                values: new object[,]
                {
                    { 1, "Basic", false, 0m },
                    { 2, "Premium", true, 99000m },
                    { 3, "VIP", false, 199000m }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Avatar", "LastMessage", "Name", "Online", "Time", "Unread" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", "Ok em, mai 2h chiều mình gặp nhau nhé!", "Đào Nguyên Trọng", true, "10:30", 2 },
                    { 2, "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face", "Ảnh đã chỉnh xong rồi nha.", "Bảo Vũ", true, "Hôm qua", 0 }
                });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "Avatar", "Bio", "CoverPhoto", "HourlyPrice", "InstantBooking", "IsOnline", "IsVerified", "Location", "Name", "PerPhotoPrice", "Rating", "ReviewCount", "TiktokPackagePrice" },
                values: new object[,]
                {
                    { 1, "/Trong.jpg", "Chuyên chụp chân dung và lifestyle với phong cách Hàn Quốc nhẹ nhàng.", "/Trong2.jpg", 200000m, true, true, true, "Quận 1, TP.HCM", "Đào Nguyên Trọng", 30000m, 4.9m, 128, 500000m },
                    { 2, "/Dang.jpg", "Phone-Grapher chuyên chụp vintage và cá tính.", "/Dang22.jpg", 180000m, false, false, true, "Quận 3, TP.HCM", "Bùi Phạm Hải Đăng", 25000m, 4.8m, 95, 450000m },
                    { 3, "/Bao.jpg", "Chuyên outdoor & lifestyle photography.", "/Bao22.jpg", 150000m, true, true, true, "Quận 7, TP.HCM", "Bảo Vũ", 20000m, 4.7m, 73, 400000m },
                    { 4, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=200&h=200&fit=crop&crop=face", "Street photographer & content creator.", "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?w=800&h=400&fit=crop", 170000m, true, true, false, "Quận Hoàn Kiếm, Hà Nội", "Hoàng Long", 22000m, 4.6m, 54, 480000m },
                    { 5, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=200&h=200&fit=crop&crop=face", "Phone-Grapher phong cách Hàn Quốc.", "https://images.unsplash.com/photo-1501785888041-af3ef285b470?w=800&h=400&fit=crop", 250000m, false, false, true, "Quận Ba Đình, Hà Nội", "Bích Ngọc", 35000m, 4.9m, 112, 600000m },
                    { 6, "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=200&h=200&fit=crop&crop=face", "Chụp ảnh đêm đẹp nhất Sài Gòn.", "https://images.unsplash.com/photo-1449824913935-59a10b8d2000?w=800&h=400&fit=crop", 160000m, true, true, true, "Quận 1, TP.HCM", "Quốc Bảo", 20000m, 4.5m, 41, 420000m }
                });

            migrationBuilder.InsertData(
                table: "Presets",
                columns: new[] { "Id", "BeforeImage", "Category", "Downloads", "Image", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=400&h=500&fit=crop", "Da sáng Hàn", 1240, "https://images.unsplash.com/photo-1524504388940-b1c1722653e1?w=400&h=500&fit=crop", "Seoul Sunrise", 49000m, 4.8m },
                    { 2, "https://images.unsplash.com/photo-1497935586351-b67a49e012bf?w=400&h=500&fit=crop", "Cafe", 890, "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085?w=400&h=500&fit=crop", "Café Latte", 39000m, 4.6m },
                    { 3, "https://images.unsplash.com/photo-1496440543089-3ef06b872312?w=400&h=500&fit=crop", "Ngoài trời", 2100, "https://images.unsplash.com/photo-1502823403499-6ccfcf4fb453?w=400&h=500&fit=crop", "Golden Hour", 59000m, 4.9m }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "Chụp ảnh chân dung, ảnh đẹp, ảnh couple", "📸", "Chụp ảnh sống ảo" },
                    { 2, "Chỉnh sửa ảnh theo phong cách", "🎨", "Edit ảnh" },
                    { 3, "Quay video TikTok, Reels content", "🎬", "Quay TikTok" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Color", "Emoji", "Name" },
                values: new object[,]
                {
                    { 1, "#FFB6C1", "🇰🇷", "Hàn Quốc" },
                    { 2, "#DEB887", "📷", "Vintage" },
                    { 3, "#FF6B6B", "🔥", "Cá tính" },
                    { 4, "#00b894", "🌿", "Lifestyle" },
                    { 5, "#a29bfe", "✨", "Minimal" }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Avatar", "Name", "Rating", "Role", "Text" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&h=100&fit=crop&crop=face", "Hương Ly", 5, "Khách hàng", "Book gấp trên PICMate mà thợ đến sau 15 phút." },
                    { 2, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&h=100&fit=crop&crop=face", "Thanh Tùng", 5, "Khách hàng", "Lần đầu dùng dịch vụ chụp ảnh qua app, ảnh ra đẹp." },
                    { 3, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", "Minh Anh", 5, "Phone-Grapher", "PICMate giúp mình tìm được nhiều khách hàng hơn." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Email", "JoinDate", "Name", "TotalBookings", "TotalSpent", "Type" },
                values: new object[,]
                {
                    { 1, true, "nguyenvana@email.com", "2025-01-15", "Nguyễn Văn A", 12, 2400000m, "Khách hàng" },
                    { 2, true, "tranthib@email.com", "2025-02-20", "Trần Thị B", 8, 1600000m, "Khách hàng" },
                    { 3, true, "trongdao@email.com", "2024-11-10", "Đào Nguyên Trọng", 45, 0m, "Phone-Grapher" }
                });

            migrationBuilder.InsertData(
                table: "MembershipFeatures",
                columns: new[] { "Id", "MembershipPlanId", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Đặt lịch thợ chụp" },
                    { 2, 1, "Chat với thợ" },
                    { 3, 2, "Tất cả tính năng Basic" },
                    { 4, 2, "Giảm 10% dịch vụ" },
                    { 5, 3, "Tất cả tính năng Premium" },
                    { 6, 3, "Giảm 20% dịch vụ" }
                });

            migrationBuilder.InsertData(
                table: "PhotographerPortfolioImages",
                columns: new[] { "Id", "ImageUrl", "PhotographerId", "SortOrder" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=600&h=800&fit=crop", 1, 1 },
                    { 2, "https://images.unsplash.com/photo-1529626455594-4ff0802cfb7e?w=600&h=800&fit=crop", 1, 2 },
                    { 3, "https://images.unsplash.com/photo-1501196354995-cbb51c65aaea?w=600&h=800&fit=crop", 2, 1 },
                    { 4, "https://images.unsplash.com/photo-1515886657613-9f3515b0c78f?w=600&h=800&fit=crop", 3, 1 },
                    { 5, "https://images.unsplash.com/photo-1492684223066-81342ee5ff30?w=600&h=800&fit=crop", 4, 1 },
                    { 6, "https://images.unsplash.com/photo-1524504388940-b1c1722653e1?w=600&h=800&fit=crop", 5, 1 },
                    { 7, "https://images.unsplash.com/photo-1501196354995-cbb51c65aaea?w=600&h=800&fit=crop", 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "PhotographerReviews",
                columns: new[] { "Id", "Avatar", "Date", "PhotographerId", "Rating", "Text", "User" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&h=100&fit=crop&crop=face", "2025-12-15", 1, 5, "Chụp quá đẹp luôn!", "Hương Ly" },
                    { 2, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&h=100&fit=crop&crop=face", "2025-11-20", 1, 5, "Book gấp mà vẫn chuyên nghiệp.", "Thanh Tùng" },
                    { 3, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", "2025-12-20", 5, 5, "Rất recommend!", "Kim Anh" }
                });

            migrationBuilder.InsertData(
                table: "PhotographerStyles",
                columns: new[] { "Id", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { 1, "Hàn Quốc", 1 },
                    { 2, "Lifestyle", 1 },
                    { 3, "Minimal", 1 },
                    { 4, "Vintage", 2 },
                    { 5, "Cá tính", 2 },
                    { 6, "Lifestyle", 2 },
                    { 7, "Lifestyle", 3 },
                    { 8, "Minimal", 3 },
                    { 9, "Hàn Quốc", 3 },
                    { 10, "Cá tính", 4 },
                    { 11, "Vintage", 4 },
                    { 12, "Hàn Quốc", 5 },
                    { 13, "Minimal", 5 },
                    { 14, "Cá tính", 6 },
                    { 15, "Vintage", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipFeatures_MembershipPlanId",
                table: "MembershipFeatures",
                column: "MembershipPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerPortfolioImages_PhotographerId",
                table: "PhotographerPortfolioImages",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerReviews_PhotographerId",
                table: "PhotographerReviews",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerStyles_PhotographerId",
                table: "PhotographerStyles",
                column: "PhotographerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "DemoAccounts");

            migrationBuilder.DropTable(
                name: "Disputes");

            migrationBuilder.DropTable(
                name: "FavoritePhotographers");

            migrationBuilder.DropTable(
                name: "MembershipFeatures");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PhotographerPortfolioImages");

            migrationBuilder.DropTable(
                name: "PhotographerReviews");

            migrationBuilder.DropTable(
                name: "PhotographerStyles");

            migrationBuilder.DropTable(
                name: "Presets");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MembershipPlans");

            migrationBuilder.DropTable(
                name: "Photographers");
        }
    }
}
