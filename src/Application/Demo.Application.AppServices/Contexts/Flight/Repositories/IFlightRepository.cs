using Demo.Application.AppServices.Specifications;
using Demo.Contracts.Flight;
using System.Linq.Expressions;

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
    /// <param name="skip">Смещение.</param>
    /// <param name="take">Размер выборки.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели рейсов <see cref="FlightDto"/></returns>
    Task<FlightDto[]> SearchAsync(ISpecification<Domain.Flight> specification,
        int skip, int take, CancellationToken cancellationToken);

    /// <summary>
    /// Получить краткую информацию о маршруте рейса.
    /// </summary>
    /// <param name="flightNo">Номер рейса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список кратких моделей маршрута рейса <see cref="FlightRouteDto"/></returns>
    Task<FlightRouteDto[]> GetFlightRoutesAsync(string flightNo, CancellationToken cancellationToken);

    /// <summary>
    /// Получить количество записей по условию.
    /// </summary>
    /// <param name="expression">Условие.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Количество записей.</returns>
    Task<int> GetCountAsync(Expression<Func<Domain.Flight, bool>> expression,
        CancellationToken cancellationToken);
}