namespace Store.BLL.DataTransferObjects.StoresProducts.Responses;

public class GetAllStoresProductsItemDto
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public Guid ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}