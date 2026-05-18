namespace PICMate.Api.Domain.Entities;

public class MembershipFeature
{
    public int Id { get; set; }
    public int MembershipPlanId { get; set; }
    public string Text { get; set; } = string.Empty;

    public MembershipPlan? MembershipPlan { get; set; }
}
