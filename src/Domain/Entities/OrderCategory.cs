namespace WiseConsulting.Domain.Entities;

public class OrderCategory : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
}