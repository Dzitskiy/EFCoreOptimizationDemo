using Demo.Application.AppServices.Contexts.Flight.Builders;
using Demo.Application.AppServices.Contexts.Flight.Repositories;
using Demo.Contracts.Flight;

namespace Demo.Application.AppServices.Contexts.Flight.Services;

/// <inheritdoc />
public class FlightService : IFlightService
{
    private readonly IFlightRepository _repository;
    private readonly IFlightPredicateBuilder _predicateBuilder;

    /// <summary>
    /// c-tor <see cref="FlightService"/>
    /// </summary>
    public FlightService(IFlightRepository repository, IFlightPredicateBuilder predicateBuilder)
    {
        _repository = repository;
        _predicateBuilder = predicateBuilder;
    }

    /// <inheritdoc />
    public Task<FlightDto[]> SearchAsync(FlightFilterRequest filter, CancellationToken cancellationToken)
    {
        var specification = _predicateBuilder.Build(filter);
        return _repository.SearchAsync(specification, cancellationToken);
    }
}