using Microsoft.EntityFrameworkCore;
using PICMate.Api.Data;
using PICMate.Api.Repositories.Interfaces;

namespace PICMate.Api.Repositories.Implementations;

public class BootstrapRepository(AppDbContext db) : IBootstrapRepository
{
    public async Task<object> GetBootstrapAsync(CancellationToken ct = default)
    {
        var photographers = await db.Photographers
            .Include(x => x.Styles)
            .Include(x => x.PortfolioImages)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        return new
        {
            photographers = photographers.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                avatar = p.Avatar,
                coverPhoto = p.CoverPhoto,
                bio = p.Bio,
                location = p.Location,
                rating = p.Rating,
                reviewCount = p.ReviewCount,
                isOnline = p.IsOnline,
                isVerified = p.IsVerified,
                instantBooking = p.InstantBooking,
                styles = p.Styles.Select(s => s.Name).ToList(),
                pricing = new { hourly = p.HourlyPrice, perPhoto = p.PerPhotoPrice, tiktokPackage = p.TiktokPackagePrice },
                portfolio = p.PortfolioImages.OrderBy(i => i.SortOrder).Select(i => i.ImageUrl).ToList(),
                reviews = p.Reviews.Select(r => new { id = r.Id, user = r.User, avatar = r.Avatar, rating = r.Rating, text = r.Text, date = r.Date }).ToList()
            }),
            services = (await db.Services.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, name = x.Name, icon = x.Icon, description = x.Description }),
            styles = (await db.Styles.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, name = x.Name, emoji = x.Emoji, color = x.Color }),
            presets = (await db.Presets.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, name = x.Name, category = x.Category, price = x.Price, image = x.Image, beforeImage = x.BeforeImage, downloads = x.Downloads, rating = x.Rating }),
            bookings = (await db.Bookings.OrderByDescending(x => x.Date).ToListAsync(ct)).Select(x => new { id = x.Id, photographerId = x.PhotographerId, photographerName = x.PhotographerName, photographerAvatar = x.PhotographerAvatar, service = x.Service, date = x.Date, time = x.Time, location = x.Location, status = x.Status, total = x.Total, note = x.Note }),
            bookingStatuses = (await db.BookingStatuses.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { key = x.Key, label = x.Label, color = x.Color }),
            demoAccounts = (await db.DemoAccounts.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { email = x.Email, password = x.Password, name = x.Name, role = x.Role, avatar = x.Avatar, redirect = x.Redirect }),
            testimonials = (await db.Testimonials.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, name = x.Name, avatar = x.Avatar, role = x.Role, rating = x.Rating, text = x.Text }),
            membershipPlans = await db.MembershipPlans.Include(x => x.Features).OrderBy(x => x.Id)
                .Select(x => new { id = x.Id, name = x.Name, price = x.Price, popular = x.Popular, features = x.Features.OrderBy(f => f.Id).Select(f => f.Text).ToList() })
                .ToListAsync(ct),
            mockUsers = (await db.Users.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, name = x.Name, email = x.Email, type = x.Type, active = x.Active, joinDate = x.JoinDate, totalBookings = x.TotalBookings, totalSpent = x.TotalSpent }),
            mockMessages = (await db.Messages.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, name = x.Name, avatar = x.Avatar, lastMessage = x.LastMessage, time = x.Time, unread = x.Unread, online = x.Online }),
            mockDisputes = (await db.Disputes.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, orderId = x.OrderId, reporter = x.Reporter, reporterAvatar = x.ReporterAvatar, against = x.Against, againstAvatar = x.AgainstAvatar, reason = x.Reason, priority = x.Priority, status = x.Status, date = x.Date, amount = x.Amount }),
            mockActivities = (await db.Activities.OrderBy(x => x.Id).ToListAsync(ct)).Select(x => new { id = x.Id, type = x.Type, text = x.Text, time = x.Time, icon = x.Icon }),
            favoritePhotographerIds = await db.FavoritePhotographers.OrderBy(x => x.Id).Select(x => x.PhotographerId).ToListAsync(ct)
        };
    }
}
