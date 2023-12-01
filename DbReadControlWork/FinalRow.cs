namespace DbReadControlWork;

public sealed class FinalRow
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    public int SalesmanId { get; set; }
    public string SalesmanName { get; set; } = null!;
    public FinalRow(Salesman salesman, Customer customer)
    {
        SalesmanId = salesman.Id;
        SalesmanName = customer.Name;
        CustomerId = customer.Id;
        CustomerName = customer.Name;
    }

    public override string ToString()
        => $"{SalesmanId}|{SalesmanName}|{CustomerId}|{CustomerName}";
}
