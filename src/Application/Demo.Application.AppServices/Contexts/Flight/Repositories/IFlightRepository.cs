using Demo.Application.AppServices.Specifications;
using Demo.Contracts.Flight;

namespace Demo.Application.AppServices.Contexts.Flight.Repositories;

/// <summary>
/// Репозиторий для работы с рейсами.
/// </summary>
public interface IFlightRepository
{
    /// <summary>
    /// Выполнить поиск рейсов.
    /// </summary>
    /// <param name="specification">Спецификация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели рейсов <see cref="FlightDto"/></returns>
    Task<FlightDto[]> SearchAsync(ISpecification<Domain.Flight> specification,
        CancellationToken cancellationToken);
}