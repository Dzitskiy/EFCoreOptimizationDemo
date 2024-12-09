using Demo.Application.AppServices.Contexts.TicketFlight.Repositories;
using Demo.Application.AppServices.Specifications;
using Demo.Contracts.TicketFlight;
using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.DataAccess.Repositories;

/// <inheritdoc/>
public class TicketFlightRepository : ITicketFlightRepository
{
    private readonly ReadOnlyDemoDbContext _dbContext;

    /// <summary>
    /// c-tor <see cref="TicketFlightRepository"/>
    /// </summary>
    public TicketFlightRepository(ReadOnlyDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public Task<TicketFlightDto[]> GetTicketFlightsAsync(string ticketNo, CancellationToken cancellationToken)
    {
        return _dbContext.TicketFlights.Where(x => x.TicketNo == ticketNo)
            .Select(x => new TicketFlightDto
            {
                FlightNo = x.Flight.FlightNo,
                TicketNo = x.TicketNo,
                PassengerName = x.TicketNoNavigation.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketFlightDto[]> GetTicketFlightsAsync(int flightId, CancellationToken cancellationToken)
    {
        // todo as split query?
        return _dbContext.TicketFlights.Where(x => x.FlightId == flightId)
            .Select(x => new TicketFlightDto
            {
                FlightNo = x.Flight.FlightNo,
                TicketNo = x.TicketNo,
                PassengerName = x.TicketNoNavigation.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketFlightDto[]> SearchAsync(ISpecification<TicketFlight> specification, CancellationToken cancellationToken)
    {
        return _dbContext.TicketFlights.Where(specification.PredicateExpression)
            .Select(x => new TicketFlightDto
            {
                FlightNo = x.Flight.FlightNo,
                TicketNo = x.TicketNo,
                PassengerName = x.TicketNoNavigation.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }
}