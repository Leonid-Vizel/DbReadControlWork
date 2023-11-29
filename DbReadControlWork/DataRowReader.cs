namespace DbReadControlWork;

/// <summary>
/// Класс-преобразователь из сивольной строки в класс <see cref="DataRow"/>
/// </summary>
public sealed class DataRowReader
{
    /// <summary>
    /// Разделитель в файле
    /// </summary>
    private static readonly string _delimeter = "|";
    /// <summary>
    /// Корректная длина параметров в строке
    /// </summary>
    private static readonly int _correctCount = 4;
    /// <summary>
    /// Метод преобразования
    /// </summary>
    /// <param name="initialRow">Строка прочитанная из файла</param>
    /// <returns>
    /// Если преобразовать не получилось - <see langword="null"/>
    /// <para></para>
    /// Если преобразование прошло успешно - объект типа <see cref="DataRow"/>
    /// </returns>
    public DataRow? ParseRow(string initialRow)
    {
        var splitted = initialRow.Split(_delimeter);
        if (splitted.Length != _correctCount)
        {
            return null;
        }
        if (!int.TryParse(splitted[0], out int resultCol1))
        {
            return null;
        }
        if (!int.TryParse(splitted[2], out int resultCol3))
        {
            return null;
        }
        if (!double.TryParse(splitted[3], out double resultCol4))
        {
            return null;
        }
        var row = new DataRow()
        {
            Id = resultCol1,
            Name = splitted[1],
            Number = resultCol3,
            NumberButBetter = resultCol4,
        };
        return row;
    }
}
