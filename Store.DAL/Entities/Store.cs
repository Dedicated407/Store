using Store.DAL.Entities.Abstract;

namespace Store.DAL.Entities;

public class Store : BaseEntity
{
    public string Name { get; set; }

    public string Address { get; set; }
}