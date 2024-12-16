namespace Demo.Contracts.Flight;

/// <summary>
/// Краткая информация о маршруте рейса.
/// </summary>
public class FlightRouteDto
{
    /// <summary>
    /// Номер рейса.
    /// </summary>
    public string FlightNo { get; set; }

    /// <summary>
    /// Запланированная дата и время вылета.
    /// </summary>
    public string ScheduledDeparture { get; set; }

    /// <summary>
    /// Аэропорт вылета.
    /// </summary>
    public string DepartureAirport { get; set; }

    /// <summary>
    /// Аэропорт прибытия.
    /// </summary>
    public string ArrivalAirport { get; set; }
}