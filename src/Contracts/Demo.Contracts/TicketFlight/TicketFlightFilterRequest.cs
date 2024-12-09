namespace Demo.Contracts.TicketFlight;

/// <summary>
/// Параметры поиска перелётов.
/// </summary>
public class TicketFlightFilterRequest
{
    /// <summary>
    /// Идентификатор рейса.
    /// </summary>
    public int? FlightId { get; set; }

    /// <summary>
    /// Тариф.
    /// </summary>
    public string Fare { get; set; }

    /// <summary>
    /// Номер билета.
    /// </summary>
    public string TicketNo { get; set; }
}