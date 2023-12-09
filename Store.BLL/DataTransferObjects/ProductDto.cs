namespace Store.BLL.DataTransferObjects;

public class ProductDto
{
    public string Name { get; set; }

    /// TODO: вопрос по поводу того, нужно ли создавать ColorsDto?
    public string Color { get; set; }

    public string? Description { get; set; }
}