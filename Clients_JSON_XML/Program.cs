using DB_Clients;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace Clients_JSON_XML
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client(1, "Ivan", "Ivanov", "0666543210");
            Client client2 = new Client(2, "Petro", "Petrov", "0953216598");
            Client client3 = new Client(3, "Sidor", "Sidorov", "0937418596");
            Client client4 = new Client(4, "Jet", "Li", "0977776622");
            DBService<Client> db = new DBService<Client>();
            db.AddItem(client1);
            db.AddItem(client2);
            db.AddItem(client3);
            //db.DeleteItem(2);
            //db.UpdateItem(0, client4);
            List<Client> clientsFromJSON=db.GetFromJSON();
            foreach (var client in clientsFromJSON)
            {
               Console.WriteLine(client);
            }
            Console.WriteLine("--------------------------------------------------");
            List<Client> clientsFromXML=db.GetFromXML();
            foreach (var client in clientsFromJSON)
            {
                Console.WriteLine(client);
            }
        }
    }
}