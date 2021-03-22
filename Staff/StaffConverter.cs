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
            if (jo["Designation"].Value<string>() == "Teaching")
                return jo.ToObject<Teaching>(serializer);

            if (jo["Designation"].Value<string>() == "Administration")
                return jo.ToObject<Administration>(serializer);
            if (jo["Designation"].Value<string>() == "Supporting")
                return jo.ToObject<Supporting>(serializer);

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
