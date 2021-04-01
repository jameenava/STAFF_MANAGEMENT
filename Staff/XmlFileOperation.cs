using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace StaffLibrary
{
    public class XmlFileOperation : Inmemory, ISerialize
    {
        public static string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        public static string fileName = Path.Combine(path, "test.xml");
        public void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(StaffList.GetType());
            using (FileStream aFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(aFile))
            {
                serializer.Serialize(streamWriter, StaffList);
            }

        }
        public void Deserialize()
        {
            using (var reader = new StreamReader(fileName))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Staff>));
                StaffList = (List<Staff>)deserializer.Deserialize(reader);
            }
        }
    }
}
