using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Converter
{
    public static class BinarySerializer
    {
        public static string SerializeToBinary<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memoryStream))
                {
                    JsonSerializer.Serialize(memoryStream, obj);
                }
                var byteArr = memoryStream.ToArray();
                return Convert.ToBase64String(byteArr);
            }
        }

        // متد برای تبدیل باینری به شیء
        public static T DeserializeFromBinary<T>(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                return JsonSerializer.Deserialize<T>(memoryStream);

            }
        }
        public static T DeserializeFromBinary<T>(string data)
        {
            byte[] binaryData = Encoding.UTF8.GetBytes(data);

            using (MemoryStream memoryStream = new MemoryStream(binaryData))
            {
                return JsonSerializer.Deserialize<T>(memoryStream);

            }
        }
    }
}
