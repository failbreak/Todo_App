using System.Xml.Linq;
using Todo_App.Dal;
using Todo_App.Model;

namespace Todo_App.Repository
{
    public class UserRepo:IUserRepo
    {
        private DataAcess _Data = new DataAcess();

        private readonly List<Users> _TodoUsers;
        public List<Users> GetUsers()
        {
            _TodoUsers.AddRange(_Data.GetUsers());
            return _TodoUsers;
        }
        public Users? GetUser(string Username) => _TodoUsers.Find(x => x.Username == Username);
    }
}
