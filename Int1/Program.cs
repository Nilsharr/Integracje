using Int1.Utils;

// var laptops = DataUtils.ReadTxtFile("katalog.txt").ToList();
var laptops = DataUtils.ReadTxtFile("../../../katalog.txt").ToList();
new DataUtils().PrintTable(laptops);

var producerCount = DataUtils.CountProducers(laptops);
foreach (var prod in producerCount.OrderByDescending(x => x.Count))
{
    Console.WriteLine($"Producent: {prod.Producer}, Ilosc: {prod.Count}");
}

Console.ReadKey();