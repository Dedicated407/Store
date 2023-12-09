using System.ComponentModel.DataAnnotations;

namespace Store.BLL.DataTransferObjects;

public class ProductDtoCommand
{
    [Required] public string Name { get; set; } = null!;

    [Required] public string Color { get; set; } = null!;

    public string? Description { get; set; }
}