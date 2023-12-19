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
            pathJSON = Environment.CurrentDirectory + @"\db.json";
            pathXML = Environment.CurrentDirectory + @"\db.xml";
        }
        
    }
}
