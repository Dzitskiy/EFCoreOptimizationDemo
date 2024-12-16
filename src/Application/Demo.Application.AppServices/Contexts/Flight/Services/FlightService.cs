using Demo.Application.AppServices.Contexts.Flight.Builders;
using Demo.Application.AppServices.Contexts.Flight.Repositories;
using Demo.Contracts.Flight;
using Demo.Contracts.Pagination;

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
    public async Task<PagedCollection<FlightDto>> SearchAsync(FlightFilterRequest filter, int pageIndex, int pageSize,
        CancellationToken cancellationToken)
    {
        var specification = _predicateBuilder.Build(filter);

        var total = await _repository.GetCountAsync(specification.PredicateExpression, cancellationToken);

        if (total == 0)
        {
            return PagedCollection<FlightDto>.Empty;
        }

        var skip = pageIndex * pageSize;

        return new PagedCollection<FlightDto>(
            await _repository.SearchAsync(specification, skip, pageSize, cancellationToken),
            total, pageIndex, pageSize);
    }

    /// <inheritdoc />
    public Task<FlightRouteDto[]> GetFlightRoutesAsync(string flightNo, CancellationToken cancellationToken)
    {
        return _repository.GetFlightRoutesAsync(flightNo, cancellationToken);
    }
}