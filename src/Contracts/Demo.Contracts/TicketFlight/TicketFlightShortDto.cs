namespace Demo.Contracts.TicketFlight;

/// <summary>
/// Краткая информация о перелёте.
/// </summary>
public class TicketFlightShortDto
{
    /// <summary>
    /// Номер билета.
    /// </summary>
    public string TicketNo { get; set; }
    
    /// <summary>
    /// Тариф.
    /// </summary>
    public string Fare { get; set; }
}