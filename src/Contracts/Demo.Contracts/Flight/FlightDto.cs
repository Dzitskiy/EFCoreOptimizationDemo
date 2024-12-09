using Demo.Contracts.TicketFlight;

namespace Demo.Contracts.Flight;

/// <summary>
/// Информация о рейсе.
/// </summary>
public class FlightDto
{
    /// <summary>
    /// Идентификатор рейса.
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Номер рейса.
    /// </summary>
    public string FlightNo { get; set; }

    /// <summary>
    /// Краткая информация о перелётах.
    /// </summary>
    public TicketFlightShortDto[] TicketFlights { get; set; }
}