namespace Demo.Contracts.Flight;

/// <summary>
/// Параметры поиска рейсов.
/// </summary>
public class FlightFilterRequest
{
    /// <summary>
    /// Код ВС.
    /// </summary>
    public string AircraftCode { get; set; }

    /// <summary>
    /// Номер рейса.
    /// </summary>
    public string FlightNo { get; set; }
}