using Store.DAL.Entities.Abstract;

namespace Store.DAL.Entities;

/// <summary>
/// Сущность - Магазин
/// </summary>
/// <table>stores</table>
public sealed class Store : BaseEntity
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Место расположения
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Связной ключ к StoreProducts
    /// </summary>
    public ICollection<StoreProduct> StoreProducts { get; } = new List<StoreProduct>();
}