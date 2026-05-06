using System.Xml.Serialization;
using TestGenerator.Models;

namespace TestGenerator;

class Program
{
    public static void Main(string[] args)
    {
        int count = int.Parse(args[1]);
        string file = args[2];

        List<PinData> pins = new List<PinData>();

        for (int i = 0; i < count; i++)
        {
            pins.Add(new PinData(
                $"Title {i}",
                $"Description {i}",
                @"C:\test.jpg"
            ));
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<PinData>));
        using (StreamWriter writer = new StreamWriter(file))
        {
            serializer.Serialize(writer, pins);
        }
    }
}