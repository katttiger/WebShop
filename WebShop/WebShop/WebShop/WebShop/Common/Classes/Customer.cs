namespace WebShop.Common.Classes
{
    public class Customer
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public Customer() { }
        public Customer(int id, string username, string password) => (Id, Username, Password) = (id, username, password);
    }
}
