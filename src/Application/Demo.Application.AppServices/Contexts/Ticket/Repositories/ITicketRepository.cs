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

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetByPassengerNameAsync(string passengerName, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetByPassengerNameLowerAsync(string passengerName, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetByPassengerNameILikeAsync(string passengerName, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetByPassengerNameCollateAsync(string passengerName, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetStartsPassengerNameAsync(string passengerName, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetStartsPassengerNameLowerAsync(string passengerName, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о билетах.
    /// </summary>
    /// <param name="passengerName">Имя пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    Task<TicketDto[]> GetStartsPassengerNameILikeAsync(string passengerName, CancellationToken cancellationToken);
}