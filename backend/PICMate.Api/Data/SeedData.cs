using Microsoft.EntityFrameworkCore;
using PICMate.Api.Domain.Entities;

namespace PICMate.Api.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Photographer>().HasData(
            new Photographer { Id = 1, Name = "Đào Nguyên Trọng", Avatar = "/Trong.jpg", CoverPhoto = "/Trong2.jpg", Bio = "Chuyên chụp chân dung và lifestyle với phong cách Hàn Quốc nhẹ nhàng.", Location = "Quận 1, TP.HCM", Rating = 4.9m, ReviewCount = 128, IsOnline = true, IsVerified = true, InstantBooking = true, HourlyPrice = 200000, PerPhotoPrice = 30000, TiktokPackagePrice = 500000 },
            new Photographer { Id = 2, Name = "Bùi Phạm Hải Đăng", Avatar = "/Dang.jpg", CoverPhoto = "/Dang22.jpg", Bio = "Phone-Grapher chuyên chụp vintage và cá tính.", Location = "Quận 3, TP.HCM", Rating = 4.8m, ReviewCount = 95, IsOnline = false, IsVerified = true, InstantBooking = false, HourlyPrice = 180000, PerPhotoPrice = 25000, TiktokPackagePrice = 450000 },
            new Photographer { Id = 3, Name = "Bảo Vũ", Avatar = "/Bao.jpg", CoverPhoto = "/Bao22.jpg", Bio = "Chuyên outdoor & lifestyle photography.", Location = "Quận 7, TP.HCM", Rating = 4.7m, ReviewCount = 73, IsOnline = true, IsVerified = true, InstantBooking = true, HourlyPrice = 150000, PerPhotoPrice = 20000, TiktokPackagePrice = 400000 },
            new Photographer { Id = 4, Name = "Hoàng Long", Avatar = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=200&h=200&fit=crop&crop=face", CoverPhoto = "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?w=800&h=400&fit=crop", Bio = "Street photographer & content creator.", Location = "Quận Hoàn Kiếm, Hà Nội", Rating = 4.6m, ReviewCount = 54, IsOnline = true, IsVerified = false, InstantBooking = true, HourlyPrice = 170000, PerPhotoPrice = 22000, TiktokPackagePrice = 480000 },
            new Photographer { Id = 5, Name = "Bích Ngọc", Avatar = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=200&h=200&fit=crop&crop=face", CoverPhoto = "https://images.unsplash.com/photo-1501785888041-af3ef285b470?w=800&h=400&fit=crop", Bio = "Phone-Grapher phong cách Hàn Quốc.", Location = "Quận Ba Đình, Hà Nội", Rating = 4.9m, ReviewCount = 112, IsOnline = false, IsVerified = true, InstantBooking = false, HourlyPrice = 250000, PerPhotoPrice = 35000, TiktokPackagePrice = 600000 },
            new Photographer { Id = 6, Name = "Quốc Bảo", Avatar = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=200&h=200&fit=crop&crop=face", CoverPhoto = "https://images.unsplash.com/photo-1449824913935-59a10b8d2000?w=800&h=400&fit=crop", Bio = "Chụp ảnh đêm đẹp nhất Sài Gòn.", Location = "Quận 1, TP.HCM", Rating = 4.5m, ReviewCount = 41, IsOnline = true, IsVerified = true, InstantBooking = true, HourlyPrice = 160000, PerPhotoPrice = 20000, TiktokPackagePrice = 420000 }
        );

        modelBuilder.Entity<PhotographerStyle>().HasData(
            new PhotographerStyle { Id = 1, PhotographerId = 1, Name = "Hàn Quốc" }, new PhotographerStyle { Id = 2, PhotographerId = 1, Name = "Lifestyle" }, new PhotographerStyle { Id = 3, PhotographerId = 1, Name = "Minimal" },
            new PhotographerStyle { Id = 4, PhotographerId = 2, Name = "Vintage" }, new PhotographerStyle { Id = 5, PhotographerId = 2, Name = "Cá tính" }, new PhotographerStyle { Id = 6, PhotographerId = 2, Name = "Lifestyle" },
            new PhotographerStyle { Id = 7, PhotographerId = 3, Name = "Lifestyle" }, new PhotographerStyle { Id = 8, PhotographerId = 3, Name = "Minimal" }, new PhotographerStyle { Id = 9, PhotographerId = 3, Name = "Hàn Quốc" },
            new PhotographerStyle { Id = 10, PhotographerId = 4, Name = "Cá tính" }, new PhotographerStyle { Id = 11, PhotographerId = 4, Name = "Vintage" },
            new PhotographerStyle { Id = 12, PhotographerId = 5, Name = "Hàn Quốc" }, new PhotographerStyle { Id = 13, PhotographerId = 5, Name = "Minimal" },
            new PhotographerStyle { Id = 14, PhotographerId = 6, Name = "Cá tính" }, new PhotographerStyle { Id = 15, PhotographerId = 6, Name = "Vintage" }
        );

        modelBuilder.Entity<PhotographerPortfolioImage>().HasData(
            new PhotographerPortfolioImage { Id = 1, PhotographerId = 1, ImageUrl = "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=600&h=800&fit=crop", SortOrder = 1 },
            new PhotographerPortfolioImage { Id = 2, PhotographerId = 1, ImageUrl = "https://images.unsplash.com/photo-1529626455594-4ff0802cfb7e?w=600&h=800&fit=crop", SortOrder = 2 },
            new PhotographerPortfolioImage { Id = 3, PhotographerId = 2, ImageUrl = "https://images.unsplash.com/photo-1501196354995-cbb51c65aaea?w=600&h=800&fit=crop", SortOrder = 1 },
            new PhotographerPortfolioImage { Id = 4, PhotographerId = 3, ImageUrl = "https://images.unsplash.com/photo-1515886657613-9f3515b0c78f?w=600&h=800&fit=crop", SortOrder = 1 },
            new PhotographerPortfolioImage { Id = 5, PhotographerId = 4, ImageUrl = "https://images.unsplash.com/photo-1492684223066-81342ee5ff30?w=600&h=800&fit=crop", SortOrder = 1 },
            new PhotographerPortfolioImage { Id = 6, PhotographerId = 5, ImageUrl = "https://images.unsplash.com/photo-1524504388940-b1c1722653e1?w=600&h=800&fit=crop", SortOrder = 1 },
            new PhotographerPortfolioImage { Id = 7, PhotographerId = 6, ImageUrl = "https://images.unsplash.com/photo-1501196354995-cbb51c65aaea?w=600&h=800&fit=crop", SortOrder = 1 }
        );

        modelBuilder.Entity<PhotographerReview>().HasData(
            new PhotographerReview { Id = 1, PhotographerId = 1, User = "Hương Ly", Avatar = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&h=100&fit=crop&crop=face", Rating = 5, Text = "Chụp quá đẹp luôn!", Date = "2025-12-15" },
            new PhotographerReview { Id = 2, PhotographerId = 1, User = "Thanh Tùng", Avatar = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&h=100&fit=crop&crop=face", Rating = 5, Text = "Book gấp mà vẫn chuyên nghiệp.", Date = "2025-11-20" },
            new PhotographerReview { Id = 3, PhotographerId = 5, User = "Kim Anh", Avatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", Rating = 5, Text = "Rất recommend!", Date = "2025-12-20" }
        );

        modelBuilder.Entity<ServiceItem>().HasData(
            new ServiceItem { Id = 1, Name = "Chụp ảnh sống ảo", Icon = "📸", Description = "Chụp ảnh chân dung, ảnh đẹp, ảnh couple" },
            new ServiceItem { Id = 2, Name = "Edit ảnh", Icon = "🎨", Description = "Chỉnh sửa ảnh theo phong cách" },
            new ServiceItem { Id = 3, Name = "Quay TikTok", Icon = "🎬", Description = "Quay video TikTok, Reels content" }
        );

        modelBuilder.Entity<StyleItem>().HasData(
            new StyleItem { Id = 1, Name = "Hàn Quốc", Emoji = "🇰🇷", Color = "#FFB6C1" },
            new StyleItem { Id = 2, Name = "Vintage", Emoji = "📷", Color = "#DEB887" },
            new StyleItem { Id = 3, Name = "Cá tính", Emoji = "🔥", Color = "#FF6B6B" },
            new StyleItem { Id = 4, Name = "Lifestyle", Emoji = "🌿", Color = "#00b894" },
            new StyleItem { Id = 5, Name = "Minimal", Emoji = "✨", Color = "#a29bfe" }
        );

        modelBuilder.Entity<Preset>().HasData(
            new Preset { Id = 1, Name = "Seoul Sunrise", Category = "Da sáng Hàn", Price = 49000, Image = "https://images.unsplash.com/photo-1524504388940-b1c1722653e1?w=400&h=500&fit=crop", BeforeImage = "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=400&h=500&fit=crop", Downloads = 1240, Rating = 4.8m },
            new Preset { Id = 2, Name = "Café Latte", Category = "Cafe", Price = 39000, Image = "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085?w=400&h=500&fit=crop", BeforeImage = "https://images.unsplash.com/photo-1497935586351-b67a49e012bf?w=400&h=500&fit=crop", Downloads = 890, Rating = 4.6m },
            new Preset { Id = 3, Name = "Golden Hour", Category = "Ngoài trời", Price = 59000, Image = "https://images.unsplash.com/photo-1502823403499-6ccfcf4fb453?w=400&h=500&fit=crop", BeforeImage = "https://images.unsplash.com/photo-1496440543089-3ef06b872312?w=400&h=500&fit=crop", Downloads = 2100, Rating = 4.9m }
        );

        modelBuilder.Entity<BookingStatus>().HasData(
            new BookingStatus { Id = 1, Key = "pending", Label = "Chờ xác nhận", Color = "warning" },
            new BookingStatus { Id = 2, Key = "confirmed", Label = "Đã nhận", Color = "info" },
            new BookingStatus { Id = 3, Key = "in_progress", Label = "Đang thực hiện", Color = "info" },
            new BookingStatus { Id = 4, Key = "completed", Label = "Hoàn thành", Color = "success" },
            new BookingStatus { Id = 5, Key = "cancelled", Label = "Đã hủy", Color = "danger" }
        );

        modelBuilder.Entity<Booking>().HasData(
            new Booking { Id = "BK-20251215-001", PhotographerId = 1, PhotographerName = "Đào Nguyên Trọng", PhotographerAvatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", Service = "Chụp ảnh sống ảo", Date = "2025-12-20", Time = "14:00", Location = "Cafe The Coffee House, Quận 1", Status = "completed", Total = 200000, Note = "Concept: Korean casual" },
            new Booking { Id = "BK-20251218-002", PhotographerId = 3, PhotographerName = "Bảo Vũ", PhotographerAvatar = "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face", Service = "Quay TikTok", Date = "2025-12-25", Time = "09:00", Location = "Phố đi bộ Nguyễn Huệ", Status = "confirmed", Total = 400000, Note = "Content review cafe + ăn vặt" }
        );

        modelBuilder.Entity<DemoAccount>().HasData(
            new DemoAccount { Id = 1, Email = "khach@picmate.vn", Password = "123456", Name = "Nguyễn Văn Khách", Role = "customer", Avatar = "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=100&h=100&fit=crop&crop=face", Redirect = "/dashboard" },
            new DemoAccount { Id = 2, Email = "photographer@picmate.vn", Password = "123456", Name = "Đào Nguyên Trọng", Role = "photographer", Avatar = "/Trong.jpg", Redirect = "/dashboard/photographer" },
            new DemoAccount { Id = 3, Email = "admin@picmate.vn", Password = "admin123", Name = "Admin PICMate", Role = "admin", Avatar = "", Redirect = "/admin" }
        );

        modelBuilder.Entity<Testimonial>().HasData(
            new Testimonial { Id = 1, Name = "Hương Ly", Avatar = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&h=100&fit=crop&crop=face", Role = "Khách hàng", Rating = 5, Text = "Book gấp trên PICMate mà thợ đến sau 15 phút." },
            new Testimonial { Id = 2, Name = "Thanh Tùng", Avatar = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&h=100&fit=crop&crop=face", Role = "Khách hàng", Rating = 5, Text = "Lần đầu dùng dịch vụ chụp ảnh qua app, ảnh ra đẹp." },
            new Testimonial { Id = 3, Name = "Minh Anh", Avatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", Role = "Phone-Grapher", Rating = 5, Text = "PICMate giúp mình tìm được nhiều khách hàng hơn." }
        );

        modelBuilder.Entity<MembershipPlan>().HasData(
            new MembershipPlan { Id = 1, Name = "Basic", Price = 0, Popular = false },
            new MembershipPlan { Id = 2, Name = "Premium", Price = 99000, Popular = true },
            new MembershipPlan { Id = 3, Name = "VIP", Price = 199000, Popular = false }
        );

        modelBuilder.Entity<MembershipFeature>().HasData(
            new MembershipFeature { Id = 1, MembershipPlanId = 1, Text = "Đặt lịch thợ chụp" },
            new MembershipFeature { Id = 2, MembershipPlanId = 1, Text = "Chat với thợ" },
            new MembershipFeature { Id = 3, MembershipPlanId = 2, Text = "Tất cả tính năng Basic" },
            new MembershipFeature { Id = 4, MembershipPlanId = 2, Text = "Giảm 10% dịch vụ" },
            new MembershipFeature { Id = 5, MembershipPlanId = 3, Text = "Tất cả tính năng Premium" },
            new MembershipFeature { Id = 6, MembershipPlanId = 3, Text = "Giảm 20% dịch vụ" }
        );

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser { Id = 1, Name = "Nguyễn Văn A", Email = "nguyenvana@email.com", Type = "Khách hàng", Active = true, JoinDate = "2025-01-15", TotalBookings = 12, TotalSpent = 2400000 },
            new AppUser { Id = 2, Name = "Trần Thị B", Email = "tranthib@email.com", Type = "Khách hàng", Active = true, JoinDate = "2025-02-20", TotalBookings = 8, TotalSpent = 1600000 },
            new AppUser { Id = 3, Name = "Đào Nguyên Trọng", Email = "trongdao@email.com", Type = "Phone-Grapher", Active = true, JoinDate = "2024-11-10", TotalBookings = 45, TotalSpent = 0 }
        );

        modelBuilder.Entity<MessageThread>().HasData(
            new MessageThread { Id = 1, Name = "Đào Nguyên Trọng", Avatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", LastMessage = "Ok em, mai 2h chiều mình gặp nhau nhé!", Time = "10:30", Unread = 2, Online = true },
            new MessageThread { Id = 2, Name = "Bảo Vũ", Avatar = "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face", LastMessage = "Ảnh đã chỉnh xong rồi nha.", Time = "Hôm qua", Unread = 0, Online = true }
        );

        modelBuilder.Entity<Dispute>().HasData(
            new Dispute { Id = "DP-001", OrderId = "BK-20251215-001", Reporter = "Nguyễn Văn A", ReporterAvatar = "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=100&h=100&fit=crop&crop=face", Against = "Đào Nguyên Trọng", AgainstAvatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", Reason = "Thợ chụp đến muộn 30 phút", Priority = "high", Status = "pending", Date = "2025-12-18", Amount = 200000 },
            new Dispute { Id = "DP-002", OrderId = "BK-20251218-002", Reporter = "Trần Thị B", ReporterAvatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face", Against = "Bảo Vũ", AgainstAvatar = "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face", Reason = "Yêu cầu hoàn tiền do thợ hủy đơn", Priority = "urgent", Status = "pending", Date = "2025-12-20", Amount = 400000 }
        );

        modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = 1, Type = "new_user", Text = "Võ Thị E đã đăng ký tài khoản mới", Time = "5 phút trước", Icon = "👤" },
            new Activity { Id = 2, Type = "booking", Text = "Đơn hàng BK-20251225-010 được tạo mới", Time = "12 phút trước", Icon = "📦" },
            new Activity { Id = 3, Type = "dispute", Text = "Khiếu nại mới từ Trần Thị B", Time = "3 giờ trước", Icon = "⚠️" }
        );

        modelBuilder.Entity<FavoritePhotographer>().HasData(
            new FavoritePhotographer { Id = 1, PhotographerId = 1 },
            new FavoritePhotographer { Id = 2, PhotographerId = 3 },
            new FavoritePhotographer { Id = 3, PhotographerId = 5 }
        );
    }
}
