namespace PICMate.Api.Domain.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string JoinDate { get; set; } = string.Empty;
    public int TotalBookings { get; set; }
    public decimal TotalSpent { get; set; }
}
