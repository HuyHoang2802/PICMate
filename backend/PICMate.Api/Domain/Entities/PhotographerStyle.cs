namespace PICMate.Api.Domain.Entities;

public class PhotographerStyle
{
    public int Id { get; set; }
    public int PhotographerId { get; set; }
    public string Name { get; set; } = string.Empty;

    public Photographer? Photographer { get; set; }
}
