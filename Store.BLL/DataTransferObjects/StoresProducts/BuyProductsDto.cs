namespace Store.BLL.DataTransferObjects.StoresProducts;

public class BuyProductsDto
{
    public Guid StoreId { get; set; }

    public decimal Money { get; set; }
}