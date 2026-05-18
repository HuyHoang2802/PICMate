namespace PICMate.Api.Domain.Queries;

public class PhotographerQuery : PagingQuery
{
    public string? Search { get; set; }
    public string? Style { get; set; }
    public bool? InstantOnly { get; set; }
}
