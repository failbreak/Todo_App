using Todo_App.Model;

namespace Todo_App.Repository
{
    public interface ITaskRepo
    {
        void AddTask(string Title, string Desc);
        void DelTask(string guid);
        void EditTask(string guid, string desc, string title, int prio, bool isComp);
        To_Do? GetTask(string guid);
    }
}
