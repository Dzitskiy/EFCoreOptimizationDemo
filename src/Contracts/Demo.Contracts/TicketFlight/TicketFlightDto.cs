namespace Demo.Contracts.TicketFlight;

/// <summary>
/// Информация о перелёте.
/// </summary>
public class TicketFlightDto
{
    /// <summary>
    /// Номер билета.
    /// </summary>
    public string TicketNo { get; set; }

    /// <summary>
    /// Номер рейса.
    /// </summary>
    public string FlightNo { get; set; }

    /// <summary>
    /// Имя пассажира.
    /// </summary>
    public string PassengerName { get; set; }
}