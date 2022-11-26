namespace WiseConsulting.Domain.Entities;

public class OrderCategory : BaseAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
}