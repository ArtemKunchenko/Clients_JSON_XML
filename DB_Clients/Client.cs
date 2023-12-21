namespace DB_Clients
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Client() { }
        public Client(int id, string name, string lastName, string phoneNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            
        }
        public override string ToString()
        {
            return $"ID: {Id} {Name} {LastName}\t Phone number: {PhoneNumber}";
        }

    }
}