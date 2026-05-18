namespace PICMate.Api.Domain.Entities;

public class PhotographerReview
{
    public int Id { get; set; }
    public int PhotographerId { get; set; }
    public string User { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;

    public Photographer? Photographer { get; set; }
}
