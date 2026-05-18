namespace PICMate.Api.Domain.Entities;

public class PhotographerPortfolioImage
{
    public int Id { get; set; }
    public int PhotographerId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int SortOrder { get; set; }

    public Photographer? Photographer { get; set; }
}
