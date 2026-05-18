namespace PICMate.Api.Domain.Queries;

public class UserQuery : PagingQuery
{
    public string? Search { get; set; }
    public string? Type { get; set; }
    public bool? Active { get; set; }
}
