using Demo.Contracts.Pagination;
using Demo.Contracts.TicketFlight;

namespace Demo.Application.AppServices.Contexts.TicketFlight.Services;

/// <summary>
/// Сервис работы с перелётами.
/// </summary>
public interface ITicketFlightService
{
    /// <summary>
    /// Получить информацию о перелётах.
    /// </summary>
    /// <param name="ticketNo">Номер билета.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    Task<TicketFlightDto[]> GetTicketFlightsAsync(string ticketNo, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о перелётах.
    /// </summary>
    /// <param name="flightId">Идетификатор рейса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    Task<TicketFlightDto[]> GetTicketFlightsAsync(int flightId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о перелётах по фильтру.
    /// </summary>
    /// <param name="filter">Параметры поиска перелётов.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    Task<PagedCollection<TicketFlightDto>> SearchAsync(TicketFlightFilterRequest filter, int pageIndex, int pageSize,
        CancellationToken cancellationToken);
}