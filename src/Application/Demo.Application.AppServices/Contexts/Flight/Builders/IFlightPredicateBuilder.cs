using Demo.Application.AppServices.Specifications;
using Demo.Contracts.Flight;

namespace Demo.Application.AppServices.Contexts.Flight.Builders;

/// <summary>
/// Конструктор запроса для поиска рейсов.
/// </summary>
public interface IFlightPredicateBuilder
{
    /// <summary>
    /// Создать предикат для поиска рейсов.
    /// </summary>
    /// <param name="filter">Запрос с фильтром.</param>
    /// <returns>Предикат.</returns>
    ISpecification<Domain.Flight> Build(FlightFilterRequest filter);
}