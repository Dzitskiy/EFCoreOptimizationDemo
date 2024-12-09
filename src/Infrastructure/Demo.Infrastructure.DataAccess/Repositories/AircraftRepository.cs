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
            query = query.AsSplitQuery();
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
}