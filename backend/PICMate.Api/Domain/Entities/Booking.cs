namespace PICMate.Api.Domain.Entities;

public class Booking
{
    public string Id { get; set; } = string.Empty;
    public int PhotographerId { get; set; }
    public string PhotographerName { get; set; } = string.Empty;
    public string PhotographerAvatar { get; set; } = string.Empty;
    public string Service { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Note { get; set; } = string.Empty;
}
