using Store.DAL.Entities.Abstract;

namespace Store.DAL.Entities;

/// <summary>
/// Связная таблица между Store и Product
/// </summary>
/// <table>stores_products</table>
public sealed class StoreProduct : BaseEntity
{
    /// <summary>
    /// Навигационное свойство для Store
    /// </summary>
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    /// <summary>
    /// Навигационное свойство для Product
    /// </summary>
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    /// <summary>
    /// Цена продукта
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество продукта
    /// </summary>
    public int Quantity { get; set; }
}