using Demo.Application.AppServices.Specifications;
using Demo.Contracts.Flight;

namespace Demo.Application.AppServices.Contexts.Flight.Builders;

public class FlightPredicateBuilder : IFlightPredicateBuilder
{
    /// <inheritdoc />
    public ISpecification<Domain.Flight> Build(FlightFilterRequest filter)
    {
        var specification = Specification<Domain.Flight>.FromPredicate(x => true);

        if (!string.IsNullOrWhiteSpace(filter.AircraftCode))
        {
            specification = specification.AndPredicate(x => x.AircraftCode == filter.AircraftCode);
        }

        if (!string.IsNullOrWhiteSpace(filter.FlightNo))
        {
            specification = specification.AndPredicate(x => x.FlightNo == filter.FlightNo);
        }

        return specification;
    }
}