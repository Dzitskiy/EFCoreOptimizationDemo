using Microsoft.AspNetCore.Mvc;
using System.Net;
using Demo.Application.AppServices.Contexts.Aircraft.Services;
using Demo.Contracts.Aircraft;

namespace Demo.Hosts.Api.Controllers;

/// <summary>
/// Контроллер для работы с ВС.
/// </summary>
[ApiController]
[Route("aircrafts")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class AircraftController : ControllerBase
{
    private readonly IAircraftService _aircraftService;

    /// <summary>
    /// c-tor <see cref="AircraftController"/>
    /// </summary>
    public AircraftController(IAircraftService aircraftService)
    {
        _aircraftService = aircraftService;
    }

    /// <summary>
    /// Получить информацию о ВС.
    /// </summary>
    /// <remarks>NOTE пример AsSplitQuery</remarks>
    /// <param name="aircraftCode">Код ВС.</param>
    /// <param name="useSplitQuery">Использовать деление запросов в БД.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель ВС <see cref="AircraftDto"/></returns>
    [HttpGet("{aircraftCode}")]
    [ProducesResponseType(typeof(AircraftDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAircraftInfoAsync(string aircraftCode,
        bool useSplitQuery = false, CancellationToken cancellationToken = default)
    {
        var result = await _aircraftService.GetAircraftInfoAsync(aircraftCode, useSplitQuery,
            cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить информацию о посадочных местах ВС.
    /// </summary>
    /// <remarks>NOTE пример параметризированных запросов</remarks>
    /// <param name="aircraftCode">Код ВС.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список моделей посадочных мест ВС <see cref="SeatDto"/></returns>
    [HttpGet("{aircraftCode}/seats")]
    [ProducesResponseType(typeof(SeatDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAircraftSeatsInfoAsync(string aircraftCode,
        CancellationToken cancellationToken)
    {
        var result = await _aircraftService.GetAircraftSeatsInfoAsync(aircraftCode, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить информацию о посадочных местах Cessna 208.
    /// </summary>
    /// <remarks>NOTE пример параметризированных запросов</remarks>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список моделей посадочных мест ВС <see cref="SeatDto"/></returns>
    [HttpGet("cessna/seats")]
    [ProducesResponseType(typeof(SeatDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCessnaSeatsInfoAsync(CancellationToken cancellationToken = default)
    {
        var result = await _aircraftService.GetCessnaSeatsInfoAsync(cancellationToken);
        return Ok(result);
    }
}