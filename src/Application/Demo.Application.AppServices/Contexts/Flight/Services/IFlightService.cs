using Demo.Contracts.Flight;
using Demo.Contracts.TicketFlight;

namespace Demo.Application.AppServices.Contexts.Flight.Services;

/// <summary>
/// Сервис работы с рейсами.
/// </summary>
public interface IFlightService
{
    /// <summary>
    /// Получить информацию о рейсах по фильтру.
    /// </summary>
    /// <param name="filter">Параметры поиска рейсов.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели рейсов <see cref="TicketFlightDto"/></returns>
    Task<FlightDto[]> SearchAsync(FlightFilterRequest filter, CancellationToken cancellationToken);
}