using Store.DAL.Entities.Enums;

namespace Store.BLL.DataTransferObjects.Products.Responses;

public class GetAllProductsWithQuantityItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Colors Color { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }
}