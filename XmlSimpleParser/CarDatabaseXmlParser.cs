using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XmlSimpleParser
{
    public static class CarDatabaseXmlParser
    {
        public static void SerializeToFile(string filePath, CarDatabase carDatabase)
        {
            if (carDatabase == null)
            {
                // Exception
                return;
            }

            if (File.Exists(filePath))
            {
                // Exception
                return;
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                    writer.WriteLine("<CarDatabase>");
                    writer.WriteLine("<Cars>");
                    foreach (var car in carDatabase.Cars)
                    {
                        writer.WriteLine($"<Car>");

                        writer.WriteLine($"<Regno>{car.Regno}</Regno>");
                        writer.WriteLine($"<Manufacturer>{car.Manufacturer}</Manufacturer>");
                        writer.WriteLine($"<Type>{car.Type}</Type>");

                        writer.WriteLine($"</Car>");
                    }
                    writer.WriteLine($"</Cars>");
                    writer.WriteLine($"</CarDatabase>");
                }
            }

        }

        public static CarDatabase DeserializeFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CarDatabase));

            using(FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return serializer.Deserialize(stream) as CarDatabase;
                
            }
        }
    }
}
