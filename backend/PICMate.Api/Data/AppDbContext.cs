using Microsoft.EntityFrameworkCore;
using PICMate.Api.Domain.Entities;

namespace PICMate.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Photographer> Photographers => Set<Photographer>();
    public DbSet<PhotographerStyle> PhotographerStyles => Set<PhotographerStyle>();
    public DbSet<PhotographerPortfolioImage> PhotographerPortfolioImages => Set<PhotographerPortfolioImage>();
    public DbSet<PhotographerReview> PhotographerReviews => Set<PhotographerReview>();
    public DbSet<ServiceItem> Services => Set<ServiceItem>();
    public DbSet<StyleItem> Styles => Set<StyleItem>();
    public DbSet<Preset> Presets => Set<Preset>();
    public DbSet<BookingStatus> BookingStatuses => Set<BookingStatus>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<DemoAccount> DemoAccounts => Set<DemoAccount>();
    public DbSet<Testimonial> Testimonials => Set<Testimonial>();
    public DbSet<MembershipPlan> MembershipPlans => Set<MembershipPlan>();
    public DbSet<MembershipFeature> MembershipFeatures => Set<MembershipFeature>();
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<MessageThread> Messages => Set<MessageThread>();
    public DbSet<Dispute> Disputes => Set<Dispute>();
    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<FavoritePhotographer> FavoritePhotographers => Set<FavoritePhotographer>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>().HasKey(x => x.Id);
        modelBuilder.Entity<Dispute>().HasKey(x => x.Id);

        modelBuilder.Entity<PhotographerStyle>()
            .HasOne(x => x.Photographer)
            .WithMany(x => x.Styles)
            .HasForeignKey(x => x.PhotographerId);

        modelBuilder.Entity<PhotographerPortfolioImage>()
            .HasOne(x => x.Photographer)
            .WithMany(x => x.PortfolioImages)
            .HasForeignKey(x => x.PhotographerId);

        modelBuilder.Entity<PhotographerReview>()
            .HasOne(x => x.Photographer)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.PhotographerId);

        modelBuilder.Entity<MembershipFeature>()
            .HasOne(x => x.MembershipPlan)
            .WithMany(x => x.Features)
            .HasForeignKey(x => x.MembershipPlanId);

        modelBuilder.Entity<RefreshToken>()
            .HasOne(x => x.DemoAccount)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.DemoAccountId);

        SeedData.Seed(modelBuilder);
    }
}
