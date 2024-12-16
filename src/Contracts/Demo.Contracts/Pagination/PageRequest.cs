namespace Demo.Contracts.Pagination;

/// <summary>
/// Запрос с информацией о пагинации.
/// </summary>
public class PageRequest
{
    /// <summary>
    /// Номер страницы (начиная с 0).
    /// </summary>
    public int PageIndex { get; set; } = 0;

    /// <summary>
    /// Размер страницы.
    /// </summary>
    public int PageSize { get; set; } = 20;
}