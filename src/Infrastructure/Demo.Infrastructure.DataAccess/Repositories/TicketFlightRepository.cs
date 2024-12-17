using Demo.Application.AppServices.Contexts.TicketFlight.Repositories;
using Demo.Application.AppServices.Specifications;
using Demo.Contracts.TicketFlight;
using Demo.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        return _dbContext.TicketFlights.Where(x => x.FlightId == flightId)
            .TagWith("Получить список перелётов по идентификатору рейса.")
            .Select(x => new TicketFlightDto
            {
                FlightNo = x.Flight.FlightNo,
                TicketNo = x.TicketNo,
                PassengerName = x.TicketNoNavigation.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TicketFlightDto[]> SearchAsync(ISpecification<TicketFlight> specification,
        int skip, int take, CancellationToken cancellationToken)
    {
        // NOTE сравнить с FlightRepository.SearchAsync
        return _dbContext.TicketFlights.Where(specification.PredicateExpression)
            .TagWith("Поиск перелётов по фильтру.")
            .OrderBy(x => x.FlightId)
            .Skip(skip).Take(take)
            .Select(x => new TicketFlightDto
            {
                FlightNo = x.Flight.FlightNo,
                TicketNo = x.TicketNo,
                PassengerName = x.TicketNoNavigation.PassengerName
            })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> GetCountAsync(Expression<Func<TicketFlight, bool>> expression,
        CancellationToken cancellationToken)
    {
        return _dbContext.TicketFlights
            .TagWith("Получить количество перелётов.")
            .CountAsync(expression, cancellationToken);
    }
}