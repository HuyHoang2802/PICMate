namespace PICMate.Api.Domain.Entities;

public class Preset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public string BeforeImage { get; set; } = string.Empty;
    public int Downloads { get; set; }
    public decimal Rating { get; set; }
}
