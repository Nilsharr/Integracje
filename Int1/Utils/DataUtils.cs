using System.Text;
using Int1.Models;

namespace Int1.Utils;

public class DataUtils
{
    private readonly string[] _headers =
    {
        "wiersz", "nazwa producenta", "przekątna ekranu", "rozdzielczość ekranu", "rodzaj powierzchni ekranu",
        "czy ekran jest dotykowy", "nazwa procesora", "liczba rdzeni fizycznych", "prędkość taktowania MHz",
        "wielkość pamięci RAM", "pojemność dysku", "rodzaj dysku", "nazwa układu graficznego",
        "pamięć układu graficznego", "nazwa systemu operacyjnego", "rodzaj napędu fizycznego w komputerze"
    };

    private readonly string _lineBreak = new('-', 236);
    private const string Separator = " | ";

    public static IEnumerable<Laptop> ReadTxtFile(string filePath, string delimiter = ";")
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Text file not found at path: {filePath}");
        }

        var laptops = new List<Laptop>();

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var line in File.ReadLines(filePath))
        {
            var data = line.Split(delimiter);

            laptops.Add(new Laptop
            {
                Producer = data[0],
                ScreenDiagonal = data[1],
                ScreenResolution = data[2],
                ScreenSurface = data[3],
                IsTouchScreen = data[4],
                Processor = data[5],
                PhysicalCores = ParseNullableInt(data[6]),
                ClockSpeed = ParseNullableInt(data[7]),
                MemorySize = data[8],
                DiskCapacity = data[9],
                DiskType = data[10],
                GraphicCard = data[11],
                GraphicCardMemory = data[12],
                OperatingSystem = data[13],
                PhysicalDriveType = data[14]
            });
        }

        return laptops;
    }

    public void PrintTable(IList<Laptop> laptops)
    {
        if (laptops is null)
        {
            throw new ArgumentNullException(nameof(laptops));
        }

        var sb = new StringBuilder();
        sb.AppendJoin(Separator, _headers).AppendLine();

        for (var i = 0; i < laptops.Count; i++)
        {
            sb.AppendLine(_lineBreak);
            sb.AppendLine(i + 1 + Separator + laptops[i]);
        }

        Console.WriteLine(sb);
    }

    public static IEnumerable<ProducerCount> CountProducers(IEnumerable<Laptop> laptops)
    {
        if (laptops is null)
        {
            throw new ArgumentNullException(nameof(laptops));
        }

        return laptops.GroupBy(laptop => laptop.Producer.ToLower()).Select(group => new ProducerCount
            {Producer = group.Key.Capitalize(), Count = group.Count()});
    }

    private static int? ParseNullableInt(string value) => int.TryParse(value, out var result) ? result : default(int?);
}