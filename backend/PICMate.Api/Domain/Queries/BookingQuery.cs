namespace PICMate.Api.Domain.Queries;

public class BookingQuery : PagingQuery
{
    public string? Status { get; set; }
}
