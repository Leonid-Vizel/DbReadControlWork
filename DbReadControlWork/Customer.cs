namespace DbReadControlWork;

/// <summary>
/// Класс описывающий продавца
/// </summary>
public sealed class Customer
{
    public int Id { get; set; }
    public int SalesmanReference { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public Customer() : base() { }

    public static Customer? ParseRow(string initialRow)
    {
        var splitted = initialRow.Split('|');
        if (splitted.Length != 4)
        {
            return null;
        }
        if (!int.TryParse(splitted[0], out int resultCol1))
        {
            return null;
        }
        if (!int.TryParse(splitted[1], out int resultCol2))
        {
            return null;
        }
        var row = new Customer()
        {
            Id = resultCol1,
            SalesmanReference = resultCol2,
            Name = splitted[2],
            City = splitted[3]
        };
        return row;
    }
}
