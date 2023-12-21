using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
namespace DB_Clients
{
    public class DBService<T>
    {
        private List<T> DataBase;
        private string pathJSON;
        private string pathXML;
        public DBService()
        {
            DataBase = new List<T>();
            //pathXML = Environment.CurrentDirectory + @"\db.json";
            pathJSON = @"D:\Files\db.json";
            //pathXML = Environment.CurrentDirectory + @"\db.xml";
            pathXML = @"D:\Files\db.xml";
        }
        private void SaveJSONFile()
        {
            string json = JsonSerializer.Serialize(DataBase);
            if (File.Exists(pathJSON))
            {
                try
                {
                    File.Delete(pathJSON);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                var file = File.Create(pathJSON);
                file.Close();
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            File.AppendAllText(pathJSON, json);
            //File.AppendAllLines(pathJSON, json.Split(','));

        }
        private void SaveXMLFile()
        {
            if (File.Exists(pathXML))
            {
                try
                {
                    File.Delete(pathXML);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(pathXML, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, DataBase);
                fs.Dispose();
            }

        }
        public void AddItem(T item)
        {
            DataBase.Add(item);
            SaveJSONFile();
            SaveXMLFile();
        }
        public List<T> GetFromJSON()
        {
            string data=File.ReadAllText(pathJSON);
            List<T> dataJSON = new List<T>();
            dataJSON=JsonSerializer.Deserialize<List<T>>(data);
            return DataBase;
        }
        public List<T> GetFromXML()
        {
            List<T> dataXML= new List<T>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(pathXML, FileMode.Open))
            {
                dataXML = xmlSerializer.Deserialize(fs) as List<T>;
                fs.Dispose();
            }
            return dataXML;
        }
        public void UpdateItem(int index, T newItem)
        {
            if (index >= 0 && index < DataBase.Count)
            {
                DataBase[index]=newItem;
                SaveJSONFile();
                SaveXMLFile();
            }

        }
        public void DeleteItem(int index)
        {
            if (index >= 0 && index < DataBase.Count)
            {
                DataBase.Remove(DataBase[index]);
                SaveJSONFile();
                SaveXMLFile();
            }

        }
    }
}
