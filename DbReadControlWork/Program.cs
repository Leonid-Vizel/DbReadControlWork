using DbReadControlWork;
using System.Text;

const int _ntfsBlockSize = 4096;
const string _salesmenFileName = "read-salesmen.txt";
const string _customerFileName = "read-customers.txt";

//Подготовка нужных инструментов
var final = new List<FinalRow>();

//Чтение в 1 цикл
using (var salesmenStream = new FileStream(_salesmenFileName, FileMode.OpenOrCreate))
using (var customerStream = new FileStream(_customerFileName, FileMode.OpenOrCreate))
using (var salesmenReader = new StreamReader(salesmenStream, Encoding.UTF8, true, _ntfsBlockSize))
using (var customerReader = new StreamReader(customerStream, Encoding.UTF8, true, _ntfsBlockSize))
{
    string? customerRow = customerReader.ReadLine();
    string? salesRow = salesmenReader.ReadLine();
    while (salesRow != null && customerRow != null)
    {
        var salesman = Salesman.Parse(salesRow);
        if (salesman != null)
        {
            while (customerRow != null)
            {
                var customer = Customer.Parse(customerRow);
                if (customer?.SalesmanReference != salesman.Id)
                {
                    break;
                }
                if (customer?.City == salesman.City)
                {
                    final.Add(new FinalRow(salesman, customer));
                }
                customerRow = customerReader.ReadLine();
            }
        }
        salesRow = salesmenReader.ReadLine();
    }
}

//Вывод результатов
Console.WriteLine($"Соответствующие строки ({final.Count}):");
final.ForEach(Console.WriteLine);