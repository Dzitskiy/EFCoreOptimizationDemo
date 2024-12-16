using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Contracts.TicketFlight;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Demo.Application.AppServices.Contexts.Flight.Services;
using Demo.Contracts.Flight;
using Demo.Contracts.Pagination;

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
    /// Получить информацию о перелётах по номеру рейса.
    /// </summary>
    /// <remarks>NOTE пример добавления индекса для поиска (ticket-flights.flight_id)</remarks>
    /// <param name="flightId">Идетификатор рейса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модели перелётов <see cref="TicketFlightDto"/></returns>
    [HttpGet("{flightId:int}/ticket-flights")]
    [ProducesResponseType(typeof(TicketFlightDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAsync(int flightId, CancellationToken cancellationToken)
    {
        var result = await _ticketFlightService.GetTicketFlightsAsync(flightId, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить краткую информацию о запланированных рейсах.
    /// </summary>
    /// <remarks>NOTE пример для Scan _ONLY_ Index (покрывающий индекс)</remarks>
    /// <param name="flightNo">Номер рейса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список кратких моделей рейса <see cref="FlightRouteDto"/></returns>
    [HttpGet("{flightNo}/routes")]
    [ProducesResponseType(typeof(FlightRouteDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetShortInfoAsync(string flightNo, CancellationToken cancellationToken)
    {
        var result = await _flightService.GetFlightRoutesAsync(flightNo, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Выполнить поиск рейсов.
    /// </summary>
    /// <remarks>NOTE пример плохо спроектированного API</remarks>
    /// <param name="filterRequest">Параметры поиска.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Коллекция перелётов <see cref="FlightDto"/></returns>
    [HttpGet("bad-search")]
    public async Task<IActionResult> BadSearchAsync([FromQuery] FlightFilterRequest filterRequest,
        CancellationToken cancellationToken)
    {
        var result = await _flightService.SearchAsync(filterRequest, 0, 100, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Выполнить поиск рейсов.
    /// </summary>
    /// <remarks>
    /// NOTE пример пагинации, спецификации
    /// NOTE пример важности порядка полей в индексе: flights -> ticket_flights (ticket_no, flight_id)
    /// NOTE поиск сразу и поиск сначала Ids, потом выборка
    /// </remarks>
    /// <param name="filterRequest">Параметры поиска.</param>
    /// <param name="pageRequest">Информация о пагинации.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Коллекция перелётов <see cref="FlightDto"/></returns>
    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(
        [FromQuery] FlightFilterRequest filterRequest,
        [FromQuery] PageRequest pageRequest,
        CancellationToken cancellationToken)
    {
        var result = await _flightService.SearchAsync(filterRequest, pageRequest.PageIndex, pageRequest.PageSize, cancellationToken);
        return Ok(result);
    }
}