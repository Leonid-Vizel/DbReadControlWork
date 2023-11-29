using DbReadControlWork;
using System.Globalization;
using System.Text;

//Настраиваем культуру древних русов (чтобы правильно double читал из файла)
CultureInfo cultureInfo = new CultureInfo("ru-RU");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
cultureInfo.NumberFormat.PercentDecimalSeparator = ".";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

//Подготовка нужных инструментов
List<DataRow> final = new List<DataRow>();
var rowReader = new DataRowReader();
var rowValidator = new DataRowValidator();

//Чтение в 1 цикл
using (FileStream fs = new FileStream("read.txt", FileMode.OpenOrCreate))
using (var streamReader = new StreamReader(fs, Encoding.UTF8, true, 4096)) //4096 - потому что это размерность кластера в NTFS
{
    string? line = streamReader.ReadLine();
    while (line != null)
    {
        DataRow? readResult = rowReader.ParseRow(line);
        if (readResult != null && rowValidator.Validate(readResult))
        {
            final.Add(readResult);
        }
        line = streamReader.ReadLine();
    }
}

//Вывод результатов
Console.WriteLine($"Соответствующие строки ({final.Count}):");
final.ForEach(Console.WriteLine);
