using Demo.Contracts.Flight;
using Demo.Contracts.Pagination;
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
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели рейсов <see cref="TicketFlightDto"/></returns>
    Task<PagedCollection<FlightDto>> SearchAsync(FlightFilterRequest filter, int pageIndex, int pageSize,
        CancellationToken cancellationToken);

    /// <summary>
    /// Получить краткую информацию о маршруте рейса.
    /// </summary>
    /// <param name="flightNo">Номер рейса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список кратких моделей маршрута рейса <see cref="FlightRouteDto"/></returns>
    Task<FlightRouteDto[]> GetFlightRoutesAsync(string flightNo, CancellationToken cancellationToken);
}