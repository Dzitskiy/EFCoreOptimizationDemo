using System.Net;
using Demo.Application.AppServices.Contexts.TicketFlight.Services;
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
    /// TODO
    /// Получить список.
    /// </summary>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Коллекция объявлений <see cref="TicketFlightDto"/></returns>
    [HttpGet("get-all-paged")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
    {
        return Ok();
    }

    /// <summary>
    /// Выполнить поиск перелётов.
    /// </summary>
    /// <param name="filterRequest">Параметры поиска.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Коллекция перелётов <see cref="TicketFlightDto"/></returns>
    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync([FromQuery] TicketFlightFilterRequest filterRequest,
        CancellationToken cancellationToken, int pageSize = 20, int pageIndex = 0)
    {
        var result = await _ticketFlightService.SearchAsync(filterRequest, cancellationToken);
        return Ok(result);
    }
}