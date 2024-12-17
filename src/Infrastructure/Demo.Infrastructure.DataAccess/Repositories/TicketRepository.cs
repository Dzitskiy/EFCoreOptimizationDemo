using Demo.Application.AppServices.Contexts.Ticket.Repositories;
using Demo.Contracts.Ticket;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.DataAccess.Repositories;

/// <inheritdoc/>
public class TicketRepository : ITicketRepository
{
    private readonly ReadOnlyDemoDbContext _dbContext;

    /// <summary>
    /// c-tor <see cref="TicketRepository"/>
    /// </summary>
    public TicketRepository(ReadOnlyDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public Task<TicketDto[]> GetByPassengerIdAsync(string passengerId, CancellationToken cancellationToken)
    {
        // NOTE добавить индекс
        // CREATE INDEX tickets_passenger_id ON bookings.tickets USING btree (passenger_id);
        // NOTE а ещё лучше - покрывающий индекс
        // CREATE INDEX tickets_passenger_id ON bookings.tickets USING btree(passenger_id) INCLUDE(ticket_no, passenger_name);
        return _dbContext.Tickets.Where(x => x.PassengerId == passengerId)
            .Select(x => new TicketDto
            {
                TicketNo = x.TicketNo,
                PassengerId = x.PassengerId,
                PassengerName = x.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketDto[]> GetByPassengerNameAsync(string passengerName, CancellationToken cancellationToken)
    {
        return _dbContext.Tickets.Where(x => x.PassengerName == passengerName)
            .Select(x => new TicketDto
            {
                TicketNo = x.TicketNo,
                PassengerId = x.PassengerId,
                PassengerName = x.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketDto[]> GetByPassengerNameLowerAsync(string passengerName, CancellationToken cancellationToken)
    {
        return _dbContext.Tickets.Where(x => x.PassengerName.ToLower() == passengerName.ToLower())
            .Select(x => new TicketDto
            {
                TicketNo = x.TicketNo,
                PassengerId = x.PassengerId,
                PassengerName = x.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketDto[]> GetByPassengerNameILikeAsync(string passengerName, CancellationToken cancellationToken)
    {
        return _dbContext.Tickets.Where(x => EF.Functions.ILike(x.PassengerName, passengerName))
            .Select(x => new TicketDto
            {
                TicketNo = x.TicketNo,
                PassengerId = x.PassengerId,
                PassengerName = x.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketDto[]> GetByPassengerNameCollateAsync(string passengerName, CancellationToken cancellationToken)
    {
        return _dbContext.Tickets.Where(x =>
                EF.Functions.Collate(x.PassengerName, "case_insensitive") == passengerName)
            .Select(x => new TicketDto
            {
                TicketNo = x.TicketNo,
                PassengerId = x.PassengerId,
                PassengerName = x.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    public Task<TicketDto[]> GetStartsPassengerNameAsync(string passengerName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TicketDto[]> GetStartsPassengerNameLowerAsync(string passengerName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TicketDto[]> GetStartsPassengerNameILikeAsync(string passengerName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}