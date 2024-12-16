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
}