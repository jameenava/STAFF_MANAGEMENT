using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace StaffLibrary
{
    public class JsonFileOperation : Inmemory,ISerialize
    {
        public static string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        public static string fileName = Path.Combine(path, "test.json");
        public void Deserialize()
        {
            try
            {
                JsonConverter[] converters = { new StaffConverter() };
                string json = File.ReadAllText(fileName);
                staffList = JsonConvert.DeserializeObject<List<Staff>>(json, new JsonSerializerSettings() { Converters = converters });

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Serialize()
        {

            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fileName))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, StaffList, typeof(Staff));
            }

        }
    }
}
