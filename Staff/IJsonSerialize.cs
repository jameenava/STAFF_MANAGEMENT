using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public interface IJsonSerialize
    {
        public void Serialize();
        public void Deserialize(JsonConverter[] converter);
    };
}
