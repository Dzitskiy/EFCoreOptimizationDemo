using Demo.Contracts.Ticket;

namespace Demo.Application.AppServices.Contexts.Ticket.Repositories;

public interface ITicketRepository
{
    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerId">Номер документа пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetByPassengerIdAsync(string passengerId, CancellationToken cancellationToken);
}