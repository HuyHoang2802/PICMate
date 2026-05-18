namespace PICMate.Api.Domain.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}
