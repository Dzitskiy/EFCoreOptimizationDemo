using Demo.Application.AppServices.Contexts.Aircraft.Repositories;
using Demo.Contracts.Aircraft;

namespace Demo.Application.AppServices.Contexts.Aircraft.Services;

/// <inheritdoc />
public class AircraftService : IAircraftService
{
    private readonly IAircraftRepository _repository;

    /// <summary>
    /// c-tor <see cref="AircraftService"/>
    /// </summary>
    public AircraftService(IAircraftRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public Task<AircraftDto> GetAircraftInfoAsync(string aircraftCode, bool useSplitQuery,
        CancellationToken cancellationToken)
    {
        return _repository.GetAircraftInfoAsync(aircraftCode, useSplitQuery, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SeatDto[]> GetAircraftSeatsInfoAsync(string aircraftCode, CancellationToken cancellationToken)
    {
        return _repository.GetAircraftSeatsInfoAsync(aircraftCode, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SeatDto[]> GetCessnaSeatsInfoAsync(CancellationToken cancellationToken)
    {
        return _repository.GetCn1SeatsInfoAsync(cancellationToken);
    }
}