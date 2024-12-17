namespace Demo.Application.AppServices.Enums;

/// <summary>
/// Способы сравнения строк.
/// </summary>
public enum StringCompareType
{
    /// <summary>
    /// Сравнение.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Сравнение с приведением к lower.
    /// </summary>
    Lower = 1,

    /// <summary>
    /// Использование ILike.
    /// </summary>
    ILike = 2,

    /// <summary>
    /// Использование правила сортировки.
    /// </summary>
    Collate = 3
}