namespace Todo_App.Model
{
    public record Users
    {
        //public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Users(string username, string password, string firstname, string lastname)
        {
            //Id = id;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
        }
        public Users() { }
    }
}
