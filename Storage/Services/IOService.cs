using System.Text.Json;
using System.Xml.Serialization;

namespace Storage.MainConsole.Services
{
    public static class IOService
    {
        public static void ReadFromXml<T>(string path, out List<T> entities)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using FileStream fs = new FileStream(path, FileMode.Open);
            entities = xmlSerializer.Deserialize(fs) as List<T>;
        }

        public static void ReadFromJson<T>(string path, out List<T> entities)
        {
            string jsonString = File.ReadAllText(path);
            entities = JsonSerializer.Deserialize<List<T>>(jsonString)!;
        }

        public static void WriteToXml<T>(string path, List<T> entities)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fs, entities);
        }

        public static void WriteToJson<T>(string path, IEnumerable<T> entities)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(entities, options);
            File.WriteAllText(path, jsonString);
        }
    }
}
