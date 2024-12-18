using System.Linq.Expressions;
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
    public async Task<FlightDto[]> SearchAsync(ISpecification<Flight> specification,
        int skip, int take, CancellationToken cancellationToken)
    {
        // NOTE поиск по Id, затем выборка по Id
        // NOTE сравнить с TicketFlightRepository.SearchAsync
        var ids = await _dbContext.Flights.Where(specification.PredicateExpression)
            .TagWith("Поиск идентификаторов рейсов по фильтру.")
            .OrderBy(x => x.FlightId)
            .Skip(skip).Take(take)
            .Select(x => x.FlightId).ToArrayAsync(cancellationToken);

        return await _dbContext.Flights.Where(x => ids.Contains(x.FlightId))
            .TagWith("Выборка рейсов по идентификаторам.")
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
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<FlightRouteDto[]> GetFlightRoutesAsync(string flightNo, CancellationToken cancellationToken)
    {
        // NOTE покрывающий индекс
        // NOTE CREATE INDEX flights_flight_no_route ON bookings.flights USING btree (flight_no) include (departure_airport, scheduled_departure, arrival_airport);
        return _dbContext.Flights.Where(x => x.FlightNo == flightNo)
            .TagWith($"Получить список маршрутов по номеру рейса {flightNo}")
            .Select(x => new FlightRouteDto
            {
                FlightNo = x.FlightNo,
                ScheduledDeparture = x.ScheduledDeparture.ToString("dd-MM-yyyy HH:mm"),
                DepartureAirport = x.DepartureAirport,
                ArrivalAirport = x.ArrivalAirport
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> GetCountAsync(Expression<Func<Flight, bool>> expression,
        CancellationToken cancellationToken)
    {
        return _dbContext.Flights
            .TagWith("Получить количество рейсов по фильтру.")
            .CountAsync(expression, cancellationToken);
    }
}