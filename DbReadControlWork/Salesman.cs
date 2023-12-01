namespace DbReadControlWork;

public sealed class Salesman
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public Salesman() : base() { }

    public static Salesman? Parse(string initialRow)
    {
        var splitted = initialRow.Split('|');
        if (splitted.Length != 3)
        {
            return null;
        }
        if (!int.TryParse(splitted[0], out int resultCol1))
        {
            return null;
        }
        var row = new Salesman()
        {
            Id = resultCol1,
            Name = splitted[1],
            City = splitted[2],
        };
        return row;
    }
}
