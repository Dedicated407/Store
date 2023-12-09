using System.Text.Json.Serialization;

namespace Store.BLL.DataTransferObjects.StoresProducts;

public class CreateStoreProductDto
{
    [JsonIgnore]
    public Guid StoreId { get; set; }

    public Guid ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}