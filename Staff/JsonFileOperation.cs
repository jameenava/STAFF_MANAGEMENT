using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace StaffLibrary
{
    public class JsonFileOP : Inmemory,ISerialize
    {
        public static string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        public static string fileName = Path.Combine(path, "test.json");
        public void Deserialize()
        {
            JsonConverter[] converters = { new StaffConverter() };
            string json = File.ReadAllText(fileName);
            staffList = JsonConvert.DeserializeObject<List<Staff>>(json, new JsonSerializerSettings() { Converters = converters });
            //staffList = JsonConvert.DeserializeObject<List<Staff>>(fileName, new JsonSerializerSettings() { Converters = converters });

        }

        public void Serialize()
        {

            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            //var result = JsonConvert.SerializeObject(allFoos)

            using (StreamWriter sw = new StreamWriter(fileName))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, StaffList, typeof(Staff));
            }
            //File.WriteAllText(fileName, JsonConvert.SerializeObject(StaffList));
            //var output = JsonConvert.SerializeObject(StaffList);
            //System.Text.Json.JsonSerializer serializer = new System.Text.Json.JsonSerializer();
            //using (FileStream aFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            //using (StreamWriter streamWriter = new StreamWriter(aFile))
            //{
            //               serializer.Serialize(streamWriter, output);
            //}

            //using (StreamWriter file = File.CreateText(fileName))
            //    {
            //        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            //        //serialize object directly into file stream
            //        serializer.Serialize(file, output);
            //    }
            //serializer.Serialize(file, StaffList);

        }
    }
}
