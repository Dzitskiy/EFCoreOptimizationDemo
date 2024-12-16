using Demo.Application.AppServices.Contexts.TicketFlight.Services;
using Demo.Contracts.TicketFlight;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Demo.Application.AppServices.Contexts.Ticket.Services;
using Demo.Contracts.Ticket;

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
    private readonly ITicketService _ticketService;

    /// <summary>
    /// c-tor <see cref="TicketFlightController"/>
    /// </summary>
    public TicketController(ITicketFlightService ticketFlightService, ITicketService ticketService)
    {
        _ticketFlightService = ticketFlightService;
        _ticketService = ticketService;
    }

    /// <summary>
    /// Получить информацию о билетах по документу пассажира.
    /// </summary>
    /// <remarks>NOTE пример добавления индекса для поиска (+ покрывающий индекс)</remarks>
    /// <param name="passengerId">Номер документа пассажира.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список билетов <see cref="TicketDto"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(TicketDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTicketsByPassengerIdAsync([FromQuery]string passengerId,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(passengerId))
        {
            return BadRequest("Не указаны параметры");
        }

        var result = await _ticketService.GetByPassengerIdAsync(passengerId, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить информацию о перелётах по номеру билета.
    /// </summary>
    /// <remarks>NOTE пример использования индекса для поиска (ticket-flights.ticket_no)</remarks>
    /// <param name="no">Номер билета.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список перелётов <see cref="TicketFlightDto"/></returns>
    [HttpGet("{no}/ticket-flights")]
    [ProducesResponseType(typeof(TicketFlightDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTicketFlightsAsync(string no, CancellationToken cancellationToken)
    {
        var result = await _ticketFlightService.GetTicketFlightsAsync(no, cancellationToken);
        return Ok(result);
    }
}