using DbReadControlWork;
using System.Text;

//Подготовка нужных инструментов
List<Tuple<Customer,Salesman>> final = new List<Tuple<Customer, Salesman>>();

//Чтение в 1 цикл
using (FileStream fsSalesman = new FileStream("read-salesmen.txt", FileMode.OpenOrCreate))
using (FileStream fsCustomer = new FileStream("read-customers.txt", FileMode.OpenOrCreate))
using (var streamReaderSalesman = new StreamReader(fsSalesman, Encoding.UTF8, true, 4096)) //4096 - потому что это размерность кластера в NTFS
using (var streamReaderCustomer = new StreamReader(fsCustomer, Encoding.UTF8, true, 4096)) //4096 - потому что это размерность кластера в NTFS
{
    string? customerRow = streamReaderCustomer.ReadLine();
    string? salesRow = streamReaderSalesman.ReadLine();
    while (customerRow != null && salesRow != null)
    {
        Customer? customerResult = Customer.ParseRow(customerRow);
        if (customerResult != null)
        {
            Salesman? salesResult = Salesman.ParseRow(salesRow);
            while (salesResult != null && customerResult.SalesmanReference == salesResult.Id)
            {
                if (customerResult?.City == salesResult?.City)
                {
                    final.Add(Tuple.Create(customerResult, salesResult));
                }
                customerRow = streamReaderCustomer.ReadLine();
                salesResult = Salesman.ParseRow(salesRow);
            }
        }
    }
}

//Вывод результатов
Console.WriteLine($"Соответствующие строки ({final.Count}):");
final.ForEach(Console.WriteLine);