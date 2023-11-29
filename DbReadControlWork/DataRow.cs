namespace DbReadControlWork;

/// <summary>
/// Класс описывающий строку нашего запроса из файла
/// </summary>
public sealed class DataRow
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Number { get; set; }
    public double NumberButBetter { get; set; }
    public DataRow() : base() { }

    public override string ToString()
        => $"{Id}|{Name}|{Number}|{NumberButBetter}";
}
