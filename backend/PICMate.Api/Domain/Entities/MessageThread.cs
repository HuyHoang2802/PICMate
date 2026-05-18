namespace PICMate.Api.Domain.Entities;

public class MessageThread
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string LastMessage { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public int Unread { get; set; }
    public bool Online { get; set; }
}
