namespace Store.DAL.Entities.Abstract;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
}