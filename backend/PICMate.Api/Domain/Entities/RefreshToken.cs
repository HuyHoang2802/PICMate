namespace PICMate.Api.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public int DemoAccountId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAtUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public bool Revoked { get; set; }

    public DemoAccount? DemoAccount { get; set; }
}
