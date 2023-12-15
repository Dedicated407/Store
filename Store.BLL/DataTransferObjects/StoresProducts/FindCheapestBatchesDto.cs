namespace Store.BLL.DataTransferObjects.StoresProducts;

public class FindCheapestBatchesDto
{
    public IEnumerable<FindCheapestBatchesItemDto> Items { get; set; }
}

public class FindCheapestBatchesItemDto
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}