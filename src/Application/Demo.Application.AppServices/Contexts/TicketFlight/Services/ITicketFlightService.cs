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
    Task<TicketFlightDto[]> GetFlightsAsync(int flightId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о перелётах по фильтру.
    /// </summary>
    /// <param name="filter">Параметры поиска перелётов.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    Task<TicketFlightDto[]> SearchAsync(TicketFlightFilterRequest filter, CancellationToken cancellationToken);
}