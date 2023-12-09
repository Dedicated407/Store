using System.Text.Json.Serialization;

namespace Store.BLL.DataTransferObjects.StoresProducts;

public class ChangeProductPriceDto
{
    [JsonIgnore]
    public Guid StoreId { get; set; }

    [JsonIgnore]
    public Guid ProductId { get; set; }

    public decimal Price { get; set; }
}