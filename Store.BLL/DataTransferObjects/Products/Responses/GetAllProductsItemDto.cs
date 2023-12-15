using Store.DAL.Entities.Enums;

namespace Store.BLL.DataTransferObjects.Products.Responses;

public class GetAllProductsItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Colors Color { get; set; }

    public string? Description { get; set; }
}