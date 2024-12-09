using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Contracts.TicketFlight;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.Hosts.Api.Controllers;

/// <summary>
/// Контроллер для работы с билетами.
/// </summary>
[ApiController]
[Route("tickets")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class TicketController : ControllerBase
{
    private readonly ITicketFlightService _ticketFlightService;

    /// <summary>
    /// c-tor <see cref="TicketFlightController"/>
    /// </summary>
    /// <param name="ticketFlightService">Сервис работы с перелётами.</param>
    public TicketController(ITicketFlightService ticketFlightService)
    {
        _ticketFlightService = ticketFlightService;
    }

    /// <summary>
    /// Получить информацию о перелётах по номеру билета.
    /// </summary>
    /// <param name="no">Номер билета.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    [HttpGet("{no}/flights")]
    [ProducesResponseType(typeof(TicketFlightDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTicketFlightsAsync(string no, CancellationToken cancellationToken)
    {
        var result = await _ticketFlightService.GetTicketFlightsAsync(no, cancellationToken);
        return Ok(result);
    }
}