using NpgsqlTypes;

namespace Demo.Domain;

/// <summary>
/// Airports (internal data)
/// </summary>
public partial class AirportsDatum
{
    /// <summary>
    /// Airport code
    /// </summary>
    public string AirportCode { get; set; }

    /// <summary>
    /// Airport name
    /// </summary>
    public string AirportName { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Airport coordinates (longitude and latitude)
    /// </summary>
    public NpgsqlPoint Coordinates { get; set; }

    /// <summary>
    /// Airport time zone
    /// </summary>
    public string Timezone { get; set; }

    public virtual ICollection<Flight> FlightArrivalAirportNavigations { get; set; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAirportNavigations { get; set; } = new List<Flight>();
}
