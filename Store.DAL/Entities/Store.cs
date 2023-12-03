using Store.DAL.Entities.Abstract;

namespace Store.DAL.Entities;

/// <summary>
/// Сущность - Магазин
/// </summary>
/// <table>stores</table>
public class Store : BaseEntity
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Место расположения
    /// </summary>
    public string Address { get; set; }
}