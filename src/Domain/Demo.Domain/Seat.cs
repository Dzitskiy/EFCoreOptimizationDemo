namespace Demo.Domain;

/// <summary>
/// Seats
/// </summary>
public partial class Seat
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; set; }

    /// <summary>
    /// Seat number
    /// </summary>
    public string SeatNo { get; set; }

    /// <summary>
    /// Travel class
    /// </summary>
    public string FareConditions { get; set; }

    public virtual AircraftsDatum AircraftCodeNavigation { get; set; }
}
