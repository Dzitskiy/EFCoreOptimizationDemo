using Demo.Contracts.Aircraft;

namespace Demo.Application.AppServices.Contexts.Aircraft.Repositories;

/// <summary>
/// Репозиторий для работы с ВС.
/// </summary>
public interface IAircraftRepository
{
    /// <summary>
    /// Получить информацию о ВС.
    /// </summary>
    /// <param name="aircraftCode">Код ВС.</param>
    /// <param name="useSplitQuery">Использовать деление запросов в БД.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель ВС <see cref="AircraftDto"/></returns>
    Task<AircraftDto> GetAircraftInfoAsync(string aircraftCode, bool useSplitQuery,
        CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о посадочных местах.
    /// </summary>
    /// <param name="aircraftCode">Код ВС.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список моделей <see cref="SeatDto"/></returns>
    Task<SeatDto[]> GetAircraftSeatsInfoAsync(string aircraftCode, CancellationToken cancellationToken);

    /// <summary>
    /// Получить информацию о посадочных местах Cessna 208.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список моделей <see cref="SeatDto"/></returns>
    Task<SeatDto[]> GetCn1SeatsInfoAsync(CancellationToken cancellationToken);
}