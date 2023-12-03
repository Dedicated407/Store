#nullable enable
using Store.DAL.Entities.Abstract;
using Store.DAL.Entities.Enums;

namespace Store.DAL.Entities;

/// <summary>
/// Сущность - Товар
/// </summary>
/// <table>products</table>
public class Product : BaseEntity
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Цвет
    /// </summary>
    public Colors Color { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
}