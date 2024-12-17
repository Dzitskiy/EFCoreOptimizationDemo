using System.Net;
using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Contracts.Pagination;
using Demo.Contracts.TicketFlight;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Hosts.Api.Controllers;

/// <summary>
/// Контроллер для работы с перелётами.
/// </summary>
[ApiController]
[Route("ticket-flights")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class TicketFlightController : ControllerBase
{
    private readonly ITicketFlightService _ticketFlightService;

    /// <summary>
    /// c-tor <see cref="TicketFlightController"/>
    /// </summary>
    /// <param name="ticketFlightService">Сервис работы с перелётами.</param>
    public TicketFlightController(ITicketFlightService ticketFlightService)
    {
        _ticketFlightService = ticketFlightService;
    }

    /// <summary>
    /// Выполнить поиск перелётов.
    /// </summary>
    /// <param name="filterRequest">Параметры поиска.</param>
    /// <param name="pageRequest">Информация о пагинации.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Коллекция перелётов <see cref="TicketFlightDto"/></returns>
    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync([FromQuery] TicketFlightFilterRequest filterRequest,
        [FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
        var result = await _ticketFlightService.SearchAsync(filterRequest,
            pageRequest.PageIndex, pageRequest.PageSize, cancellationToken);
        return Ok(result);
    }
}