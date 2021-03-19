using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace StaffLibrary
{
   public class XmlFileOp: Inmemory,ISerialize
    {
        public static string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName; // return the application.exe current folder
        public static string fileName = Path.Combine(path, "test.xml");
        public void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(StaffList.GetType());
            //Console.WriteLine("haii");
            
            //Stream xmlFile = new FileStream(fileName, FileMode.Append);
            //using XmlTextWriter textWritter = new XmlTextWriter(xmlFile, Encoding.Default);
            using (FileStream aFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(aFile))
            {
                serializer.Serialize(streamWriter, StaffList);
            }

        }
        public void Deserialize()
        {
            //List<Staff> list;
            using (var reader = new StreamReader(fileName))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Staff>));
                   // new XmlRootAttribute("Staff"));
                StaffList = (List<Staff>)deserializer.Deserialize(reader);
            }
            
            //XmlSerializer deserializer = new XmlSerializer(typeof(Inmemory));
            //TextReader reader = new StreamReader(fileName);
            //object obj = deserializer.Deserialize(reader);
            //Inmemory XmlData = (Inmemory)obj;
            //reader.Close();
            //return XmlData;
        }
    }
}
