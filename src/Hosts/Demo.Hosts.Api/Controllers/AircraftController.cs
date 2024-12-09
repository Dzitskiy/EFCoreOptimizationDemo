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
    /// <param name="aircraftCode">Код ВС.</param>
    /// <param name="useSplitQuery">Использовать деление запросов в БД.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель ВС <see cref="AircraftDto"/></returns>
    [HttpGet("{aircraftCode}")]
    [ProducesResponseType(typeof(AircraftDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetFlightTicketIdAsync(string aircraftCode,
        bool useSplitQuery = false, CancellationToken cancellationToken = default)
    {
        var result = await _aircraftService.GetAircraftInfoAsync(aircraftCode, useSplitQuery,
            cancellationToken);
        return Ok(result);
    }
}