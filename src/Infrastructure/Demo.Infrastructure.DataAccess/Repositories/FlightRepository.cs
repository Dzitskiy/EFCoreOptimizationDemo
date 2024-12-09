using Demo.Application.AppServices.Contexts.Flight.Repositories;
using Demo.Application.AppServices.Specifications;
using Demo.Contracts.Flight;
using Demo.Contracts.TicketFlight;
using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.DataAccess.Repositories;

/// <inheritdoc/>
public class FlightRepository : IFlightRepository
{
    private readonly ReadOnlyDemoDbContext _dbContext;

    /// <summary>
    /// c-tor <see cref="FlightRepository"/>
    /// </summary>
    public FlightRepository(ReadOnlyDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public Task<FlightDto[]> SearchAsync(ISpecification<Flight> specification, CancellationToken cancellationToken)
    {
        // AsSplitQuery работает
        // return _dbContext.Flights.Where(specification.PredicateExpression)
        //     .AsSplitQuery()
        //     .Select(x => new FlightDto
        //     {
        //         FlightNo = x.FlightNo,
        //         FlightId = x.FlightId,
        //         TicketFlights = x.TicketFlights.Select(t => new TicketFlightShortDto
        //         {
        //             // FlightNo = x.FlightNo, // todo нужен?
        //             TicketNo = t.TicketNo,
        //             Fare = t.FareConditions
        //         }).ToArray()
        //     })
        //     .Take(100)
        //     .ToArrayAsync(cancellationToken);


        return _dbContext.Flights.Where(specification.PredicateExpression)
            .AsSplitQuery()
            .Select(x => new FlightDto
            {
                FlightNo = x.FlightNo,
                FlightId = x.FlightId,
                TicketFlights = x.TicketFlights.Select(t => new TicketFlightShortDto
                {
                    TicketNo = t.TicketNo,
                    Fare = t.FareConditions
                }).ToArray()
            })
            .Take(100)
            .ToArrayAsync(cancellationToken);
    }
}