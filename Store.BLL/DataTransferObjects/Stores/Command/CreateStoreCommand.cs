using System.ComponentModel.DataAnnotations;

namespace Store.BLL.DataTransferObjects.Stores.Command;

public class CreateStoreCommand
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }
}