using WiseConsulting.Application.Common.Mappings;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Application.OrderCategories.Queries.GetOrderCategoriesWithPagination;

public class OrderCategoryVm : IMapFrom<OrderCategory>
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
}