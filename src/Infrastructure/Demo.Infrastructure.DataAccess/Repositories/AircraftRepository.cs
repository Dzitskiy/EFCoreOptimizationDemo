using Demo.Application.AppServices.Contexts.Aircraft.Repositories;
using Demo.Contracts.Aircraft;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.DataAccess.Repositories;

/// <inheritdoc/>
public class AircraftRepository : IAircraftRepository
{
    private readonly ReadOnlyDemoDbContext _dbContext;

    /// <summary>
    /// c-tor <see cref="AircraftRepository"/>
    /// </summary>
    public AircraftRepository(ReadOnlyDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public Task<AircraftDto> GetAircraftInfoAsync(string aircraftCode, bool useSplitQuery,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.AircraftsData.Where(x => x.AircraftCode == aircraftCode)
            .TagWith($"Query AircraftData with UseSplitQuery={useSplitQuery}");

        if (useSplitQuery)
        {
            return query
                .AsSplitQuery()
                .Select(x => new AircraftDto
                {
                    AircraftCode = x.AircraftCode,
                    AircraftModelInfo = x.Model,
                    Seats = x.Seats.Select(s => new SeatDto
                    {
                        No = s.SeatNo,
                        Fare = s.FareConditions
                    }).ToArray()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        return query
            .Select(x => new AircraftDto
            {
                AircraftCode = x.AircraftCode,
                AircraftModelInfo = x.Model,
                Seats = x.Seats.Select(s => new SeatDto
                {
                    No = s.SeatNo,
                    Fare = s.FareConditions
                }).ToArray()
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<SeatDto[]> GetAircraftSeatsInfoAsync(string aircraftCode, CancellationToken cancellationToken)
    {
        var query = _dbContext.Seats.Where(x => x.AircraftCode == aircraftCode)
            .TagWith($"Query Aircraft Seats for AircraftCode={aircraftCode}");

        return query
            .Select(s => new SeatDto { No = s.SeatNo, Fare = s.FareConditions })
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<SeatDto[]> GetCn1SeatsInfoAsync(CancellationToken cancellationToken)
    {
        var query = _dbContext.Seats.Where(x => x.AircraftCode == "CN1")
            .TagWith("Query Aircraft Seats for CN1");

        return query
            .Select(s => new SeatDto { No = s.SeatNo, Fare = s.FareConditions })
            .ToArrayAsync(cancellationToken);
    }
}