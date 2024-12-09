using Demo.Application.AppServices.Specifications;
using Demo.Contracts.TicketFlight;

namespace Demo.Application.AppServices.Contexts.TicketFlight.Builders;

public class TicketFlightPredicateBuilder : ITicketFlightPredicateBuilder
{
    /// <inheritdoc />
    public ISpecification<Domain.TicketFlight> Build(TicketFlightFilterRequest filter)
    {
        var specification = Specification<Domain.TicketFlight>.FromPredicate(x => true);

        if (filter.FlightId.HasValue)
        {
            specification = specification.AndPredicate(x => x.FlightId == filter.FlightId.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.Fare))
        {
            specification = specification.AndPredicate(x => x.FareConditions == filter.Fare);
        }

        if (!string.IsNullOrWhiteSpace(filter.TicketNo))
        {
            specification = specification.AndPredicate(x => x.TicketNo == filter.TicketNo);
        }

        return specification;
    }
}