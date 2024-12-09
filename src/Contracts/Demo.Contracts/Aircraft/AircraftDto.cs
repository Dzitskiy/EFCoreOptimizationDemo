namespace Demo.Contracts.Aircraft;

/// <summary>
/// Информация о ВС.
/// </summary>
public class AircraftDto
{
    /// <summary>
    /// Код ВС.
    /// </summary>
    public string AircraftCode { get; set; }

    /// <summary>
    /// Информация о ВС.
    /// </summary>
    public string AircraftModelInfo { get; set; }

    /// <summary>
    /// Информация о посадочных местах.
    /// </summary>
    public SeatDto[] Seats { get; set; }
}