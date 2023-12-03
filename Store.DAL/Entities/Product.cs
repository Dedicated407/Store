using Store.DAL.Entities.Abstract;

namespace Store.DAL.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
}