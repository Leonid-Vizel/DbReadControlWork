namespace DbReadControlWork;

/// <summary>
/// Класс-валидатор для проверки условий пригодности строки
/// </summary>
public sealed class DataRowValidator
{
    /// <summary>
    /// Метод проверки условий пригодности строки
    /// </summary>
    /// <returns>
    /// <see langword="true"/> - Если строка подходит под условия
    /// <para></para>
    /// <see langword="false"/> - Не подходит
    /// </returns>
    public bool Validate(DataRow row)
    {
        bool validation1 = row.Name.StartsWith("П");
        bool validation2 = row.Number > 0;
        bool validation3 = row.NumberButBetter != 0;
        return validation1 && (validation2 || validation3);
    }
}
