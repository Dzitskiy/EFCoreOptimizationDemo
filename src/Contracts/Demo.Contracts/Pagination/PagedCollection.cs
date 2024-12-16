namespace Demo.Contracts.Pagination;

/// <summary>Коллекция с поддержкой пагинации.</summary>
/// <typeparam name="T">Тип объекта.</typeparam>
public class PagedCollection<T> where T : class
{
    /// <summary>
    /// Пустая коллекция.
    /// </summary>
    public static readonly PagedCollection<T> Empty = new(Array.Empty<T>(), 0, 0, 0);

    /// <summary>
    /// Инициализирует экземпляр <see cref="PagedCollection{T}"/>.
    /// </summary>
    /// <param name="data">Данные выбранной сраницы.</param>
    /// <param name="total">Всего записей.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    public PagedCollection(IReadOnlyCollection<T> data, int total, int pageIndex, int pageSize)
    {
        Data = data;
        Total = total;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    /// <summary>
    /// Записи на странице.
    /// </summary>
    public IReadOnlyCollection<T> Data { get; }

    /// <summary>
    /// Общее количество записей.
    /// </summary>
    public int Total { get; }

    /// <summary>
    /// Номер страницы.
    /// </summary>
    public int PageIndex { get; }

    /// <summary>
    /// Размер страницы.
    /// </summary>
    public int PageSize { get; }
}