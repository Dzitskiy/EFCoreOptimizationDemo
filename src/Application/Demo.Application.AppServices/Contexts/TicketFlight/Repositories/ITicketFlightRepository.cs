using Demo.Application.AppServices.Specifications;
using Demo.Contracts.TicketFlight;

namespace Demo.Application.AppServices.Contexts.TicketFlight.Repositories;

/// <summary>
/// Репозиторий для работы с перелётами.
/// </summary>
public interface ITicketFlightRepository
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
    /// Выполнить поиск перелётов.
    /// </summary>
    /// <param name="specification">Спецификация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    Task<TicketFlightDto[]> SearchAsync(ISpecification<Domain.TicketFlight> specification, CancellationToken cancellationToken);
}