using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Todo_App.Model;
namespace Todo_App.Dal
{
    public class DataAcess
    {
        private SqlCommand _cmd;
        private SqlDataReader _reader;
        private SqlConnection _conn;
        public static IConfigurationRoot Configuration { get; private set; }
        static string connectionString;

        public DataAcess()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            connectionString = Configuration.GetConnectionString("DefaultConnection");
            _conn = new SqlConnection(connectionString);
        }

        public To_Do AddTodo(To_Do doto)
        {
            _cmd = new SqlCommand("AddTodo", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _cmd.Parameters.AddWithValue("@TodoGuid", doto.GUID);
            _cmd.Parameters.AddWithValue("@TodoName", doto.TaskTitle);
            _cmd.Parameters.AddWithValue("@TodoDescript", doto.TaskDescription);
            _cmd.Parameters.AddWithValue("@PrioID", (int)doto.TaskPriority + 1);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            return doto;
        }
        public To_Do CompTodo(To_Do doto)
        {
            _cmd = new SqlCommand("CompTodo", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _cmd.Parameters.AddWithValue("@TodoGuid", doto.GUID);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            return doto;
        }

        public List<To_Do> GetTodo()
        {
            
            List<To_Do> Todolist = new();
            _cmd = new SqlCommand("GetAllTableInfo", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Guid.TryParse(_reader.GetString("TodoGuid"), out Guid result);
                To_Do ListTodo = new To_Do()
                {
                    TaskTitle = _reader.GetString("TodoName"),
                    TaskDescription = _reader.GetString("TodoDescript"),
                    TaskPriority = (To_Do.Priority)_reader.GetInt32("TodoPrior"),
                    IsCompleted = _reader.GetBoolean("IsCompleted"),
                    Created = _reader.GetDateTime("Created"),
                    GUID = result
                };
                Todolist.Add(ListTodo);
            }
            _conn.Close();
            return Todolist;
        }
        public To_Do EditTodo(To_Do doto)
        {
            _cmd = new SqlCommand("EditTodo", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _cmd.Parameters.AddWithValue("@TodoGuid", doto.GUID);
            _cmd.Parameters.AddWithValue("@TodoName", doto.TaskTitle);
            _cmd.Parameters.AddWithValue("@TodoDescript", doto.TaskDescription);
            _cmd.Parameters.AddWithValue("@IsCompleted", doto.IsCompleted);
            _cmd.Parameters.AddWithValue("@PrioId", (int)doto.TaskPriority + 1);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            return doto;
        }
        public To_Do DelTodo(To_Do doto)
        {
            _cmd = new SqlCommand("DelTodo", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _cmd.Parameters.AddWithValue("@TodoGuid", doto.GUID);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            return doto;
        }

        public To_Do DelAllTodo(To_Do doto)
        {
            _cmd = new SqlCommand("DelAllTodo", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _cmd.Parameters.AddWithValue("@TodoGuid", doto.GUID);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            return doto;
        }

        //public Users Login(Users us)
        //{
        //    List<Users> userList = new();
        //    _cmd = new SqlCommand("TodoLogin", _conn) { CommandType = CommandType.StoredProcedure };
        //    _conn.Open();
        //    _cmd.Parameters.AddWithValue("@username", us.Username);
        //    _cmd.Parameters.AddWithValue("@Password", us.Password);
        //    _reader = _cmd.ExecuteReader();
        //    while (_reader.Read())
        //    {
        //        Users user = new Users()
        //        {
        //            Username = _reader.GetString("Username"),
        //            Password = _reader.GetString("Userpass"),
        //            Firstname = _reader.GetString("Firstname"),
        //            Lastname = _reader.GetString("Lastname")
        //        };
        //        userList.Add(user);
        //    }
             
        //    _conn.Close();
        //    return us;
        //}
        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            _cmd = new SqlCommand("GetUsers", _conn) { CommandType = CommandType.StoredProcedure };
            _conn.Open();
            _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Users user = new Users()
                {
                    Username = _reader.GetString("Username"),
                    Password = _reader.GetString("Userpass"),
                    Firstname = _reader.GetString("Firstname"),
                    Lastname = _reader.GetString("Lastname")
                };
                users.Add(user);
            }
                _conn.Close();
                return users;
        }
    }


}
