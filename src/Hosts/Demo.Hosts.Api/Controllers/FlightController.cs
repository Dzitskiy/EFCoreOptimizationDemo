using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Contracts.TicketFlight;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Demo.Application.AppServices.Contexts.Flight.Services;
using Demo.Contracts.Flight;

namespace Demo.Hosts.Api.Controllers;

/// <summary>
/// Контроллер для работы с рейсами.
/// </summary>
[ApiController]
[Route("flights")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;
    private readonly ITicketFlightService _ticketFlightService;

    /// <summary>
    /// c-tor <see cref="FlightController"/>
    /// </summary>
    public FlightController(IFlightService flightService, ITicketFlightService ticketFlightService)
    {
        _flightService = flightService;
        _ticketFlightService = ticketFlightService;
    }

    /// <summary>
    /// Получить информацию о перелёте по номеру билета.
    /// </summary>
    /// <param name="flightId">Идетификатор рейса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели перелётов <see cref="TicketFlightDto"/></returns>
    [HttpGet("{flightId:int}/flights")]
    [ProducesResponseType(typeof(TicketFlightDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByIdAsync(int flightId, CancellationToken cancellationToken)
    {
        var result = await _ticketFlightService.GetFlightsAsync(flightId, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Выполнить поиск рейсов.
    /// </summary>
    /// <param name="filterRequest">Параметры поиска.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Коллекция перелётов <see cref="FlightDto"/></returns>
    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync([FromQuery] FlightFilterRequest filterRequest,
        CancellationToken cancellationToken, int pageSize = 20, int pageIndex = 0)
    {
        var result = await _flightService.SearchAsync(filterRequest, cancellationToken);
        return Ok(result);
    }
}