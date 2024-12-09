using Demo.Contracts.Aircraft;

namespace Demo.Application.AppServices.Contexts.Aircraft.Services;

/// <summary>
/// Сервис работы с ВС.
/// </summary>
public interface IAircraftService
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
}