using Demo.Application.AppServices.Contexts.Ticket.Repositories;
using Demo.Contracts.Ticket;

namespace Demo.Application.AppServices.Contexts.Ticket.Services;

/// <inheritdoc />
public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    /// <summary>
    /// c-tor <see cref="TicketService"/>
    /// </summary>
    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public Task<TicketDto[]> GetByPassengerIdAsync(string passengerId, CancellationToken cancellationToken)
    {
        return _repository.GetByPassengerIdAsync(passengerId, cancellationToken);
    }
}