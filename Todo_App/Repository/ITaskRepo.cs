using Todo_App.Model;

namespace Todo_App.Repository
{
    public interface ITaskRepo
    {
        void AddTask(To_Do.Priority priot, string Title, string Desc);
        void CompTask(string guid);
        void DelTask(string guid);
        void EditTask(string guid, string desc, string title, int prio, bool isComp);
        List<To_Do> GetallTask();
        To_Do? GetTask(string guid);
    }
}
