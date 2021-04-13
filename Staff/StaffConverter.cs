using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using StaffLibrary;

namespace StaffLibrary
{
    public class StaffConverter: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Staff));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            
            JObject jo = JObject.Load(reader);
            if (jo["Designation"].Value<int>() == 1)
                return serializer.Deserialize<Teaching>(reader);
               // return jo.ToObject<Teaching>();

            //return jo.<Teaching>(serializer);

            if (jo["Designation"].Value<int>() == 2)
                return serializer.Deserialize<Administration>(reader);
                //return jo.ToObject<Administration>();
            if (jo["Designation"].Value<int>() == 3)
               return serializer.Deserialize<Supporting>(reader);
                //return jo.ToObject<Supporting>();

            return null;
        }
         
        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
