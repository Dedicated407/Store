namespace Store.BLL.DataTransferObjects.StoresProducts;

public class BuyBatchDto
{
    public Guid StoreId { get; set; }

    public IEnumerable<FindCheapestBatchesItemDto> Items { get; set; }
}