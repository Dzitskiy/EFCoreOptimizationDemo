namespace Demo.Contracts.Aircraft;

/// <summary>
/// Информация о посадочном месте.
/// </summary>
public class SeatDto
{
    /// <summary>
    /// Номер.
    /// </summary>
    public string No { get; set; }

    /// <summary>
    /// Тариф.
    /// </summary>
    public string Fare { get; set; }
}