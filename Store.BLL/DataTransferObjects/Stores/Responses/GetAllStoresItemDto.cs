namespace Store.BLL.DataTransferObjects.Stores.Responses;

public class GetAllStoresItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }
}