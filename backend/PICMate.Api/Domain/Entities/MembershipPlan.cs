namespace PICMate.Api.Domain.Entities;

public class MembershipPlan
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool Popular { get; set; }
    public ICollection<MembershipFeature> Features { get; set; } = new List<MembershipFeature>();
}
