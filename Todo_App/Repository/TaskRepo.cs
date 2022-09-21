using Todo_App.Model;

namespace Todo_App.Repository
{
    public class TaskRepo:ITaskRepo
    {
        private readonly List<To_Do> _toDoList;

        public TaskRepo()
        {
            _toDoList = new List<To_Do>();
        }

        /// <summary>
        ///  Adds a task to the list
        /// </summary>
        /// <param name="priot"></param>
        /// <param name="Title"></param>
        /// <param name="Desc"></param>
        public void AddTask(To_Do.Priority priot, string Title, string Desc) => _toDoList.Add(new(priot, Title, Desc));

        /// <summary>
        /// Finds a specific thing from list using guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public To_Do? GetTask(string guid) => _toDoList.Find(x => x.GUID.ToString() == guid);

        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <returns></returns>
        public List<To_Do> GetallTask() => _toDoList;
        /// <summary>
        /// edits a specific task
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="desc"></param>
        /// <param name="title"></param>
        /// <param name="prio"></param>
        /// <param name="isComp"></param>
        public void EditTask(string guid, string desc, string title, int prio, bool isComp)
        {
            To_Do? todo = GetTask(guid);
            todo.TaskTitle = string.IsNullOrEmpty(title) ? todo.TaskTitle : title;
            todo.TaskDescription = string.IsNullOrEmpty(desc) ? todo.TaskDescription : desc;
            todo.TaskPriority = (To_Do.Priority)prio;
            todo.IsCompleted = isComp;
        }

        /// <summary>
        /// Deletes a specific task using guid
        /// </summary>
        /// <param name="guid"></param>
        public void DelTask(string guid)
        {
            _toDoList.Remove(GetTask(guid));
        }
            
        /// <summary>
        /// Sets a specific Task status as complete
        /// </summary>
        /// <param name="guid"></param>
        public void CompTask(string guid) => GetTask(guid).IsCompleted = true;
        /// <summary>
        /// deletes all tasks
        /// </summary>
        public void DelAll() => _toDoList.RemoveAll(x => x.IsCompleted);
    }
}
