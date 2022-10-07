using Todo_App.Model;

namespace Todo_App.Repository
{
    public interface IUserRepo
    {
        List<Users> GetUsers();
        //List<Users> Login(string Username, string Password);
    }
}
