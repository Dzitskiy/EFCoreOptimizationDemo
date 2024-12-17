using Demo.Application.AppServices.Contexts.TicketFlight.Builders;
using Demo.Application.AppServices.Contexts.TicketFlight.Repositories;
using Demo.Contracts.Pagination;
using Demo.Contracts.TicketFlight;

namespace Demo.Application.AppServices.Contexts.TicketFlight.Services;

/// <inheritdoc />
public class TicketFlightService : ITicketFlightService
{
    private readonly ITicketFlightRepository _repository;
    private readonly ITicketFlightPredicateBuilder _predicateBuilder;

    /// <summary>
    /// c-tor <see cref="TicketFlightService"/>
    /// </summary>
    public TicketFlightService(ITicketFlightRepository repository,
        ITicketFlightPredicateBuilder predicateBuilder)
    {
        _repository = repository;
        _predicateBuilder = predicateBuilder;
    }

    /// <inheritdoc />
    public Task<TicketFlightDto[]> GetTicketFlightsAsync(string ticketNo, CancellationToken cancellationToken)
    {
        return _repository.GetTicketFlightsAsync(ticketNo, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TicketFlightDto[]> GetTicketFlightsAsync(int flightId, CancellationToken cancellationToken)
    {
        return _repository.GetTicketFlightsAsync(flightId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<PagedCollection<TicketFlightDto>> SearchAsync(TicketFlightFilterRequest filter,
        int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var specification = _predicateBuilder.Build(filter);

        var total = await _repository.GetCountAsync(specification.PredicateExpression, cancellationToken);

        if (total == 0)
        {
            return PagedCollection<TicketFlightDto>.Empty;
        }

        var skip = pageIndex * pageSize;

        return new PagedCollection<TicketFlightDto>(
            await _repository.SearchAsync(specification, skip, pageSize, cancellationToken),
            total, pageIndex, pageSize);
    }
}