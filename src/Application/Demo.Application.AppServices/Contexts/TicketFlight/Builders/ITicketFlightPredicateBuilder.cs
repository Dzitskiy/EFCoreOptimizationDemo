using Demo.Application.AppServices.Specifications;
using Demo.Contracts.TicketFlight;

namespace Demo.Application.AppServices.Contexts.TicketFlight.Builders;

/// <summary>
/// Конструктор запроса для поиска рейсов.
/// </summary>
public interface ITicketFlightPredicateBuilder
{
    /// <summary>
    /// Создать предикат для поиска рейсов.
    /// </summary>
    /// <param name="filter">Запрос с фильтром.</param>
    /// <returns>Предикат.</returns>
    ISpecification<Domain.TicketFlight> Build(TicketFlightFilterRequest filter);
}