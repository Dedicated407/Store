using Store.DAL.Entities.Enums;

namespace Store.BLL.DataTransferObjects;

public class ProductDto
{
    public string Name { get; set; } = null!;

    /// TODO: вопрос по поводу того, нужно ли создавать ColorsDto?
    public Colors Color { get; set; }

    public string? Description { get; set; }
}