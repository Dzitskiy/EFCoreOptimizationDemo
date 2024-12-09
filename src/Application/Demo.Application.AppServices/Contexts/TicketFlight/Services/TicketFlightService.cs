using Demo.Application.AppServices.Contexts.TicketFlight.Builders;
using Demo.Application.AppServices.Contexts.TicketFlight.Repositories;
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
    public Task<TicketFlightDto[]> GetFlightsAsync(int flightId, CancellationToken cancellationToken)
    {
        return _repository.GetTicketFlightsAsync(flightId, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TicketFlightDto[]> SearchAsync(TicketFlightFilterRequest filter, CancellationToken cancellationToken)
    {
        var specification = _predicateBuilder.Build(filter);
        return _repository.SearchAsync(specification, cancellationToken);
    }
}