namespace PICMate.Api.Domain.Entities;

public class Dispute
{
    public string Id { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string Reporter { get; set; } = string.Empty;
    public string ReporterAvatar { get; set; } = string.Empty;
    public string Against { get; set; } = string.Empty;
    public string AgainstAvatar { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
