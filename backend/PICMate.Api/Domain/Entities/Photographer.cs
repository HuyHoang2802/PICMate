namespace PICMate.Api.Domain.Entities;

public class Photographer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string CoverPhoto { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public int ReviewCount { get; set; }
    public bool IsOnline { get; set; }
    public bool IsVerified { get; set; }
    public bool InstantBooking { get; set; }
    public decimal HourlyPrice { get; set; }
    public decimal PerPhotoPrice { get; set; }
    public decimal TiktokPackagePrice { get; set; }

    public ICollection<PhotographerStyle> Styles { get; set; } = new List<PhotographerStyle>();
    public ICollection<PhotographerPortfolioImage> PortfolioImages { get; set; } = new List<PhotographerPortfolioImage>();
    public ICollection<PhotographerReview> Reviews { get; set; } = new List<PhotographerReview>();
}
