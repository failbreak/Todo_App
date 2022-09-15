﻿using Todo_App.Model;

namespace Todo_App.Repository
{
    public class TaskRepo:ITaskRepo
    {
        private readonly List<To_Do> _toDoList;

        public TaskRepo()
        {
            _toDoList = new List<To_Do>();
        }
        public void AddTask(string Title, string Desc) => _toDoList.Add(new(Title, Desc));

        public To_Do? GetTask(string guid) => _toDoList.Find(x => x.GUID.ToString() == guid);
        public void EditTask(string guid, string desc, string title, int prio, bool isComp)
        {
            To_Do? todo = GetTask(guid);
            todo.TaskTitle = string.IsNullOrEmpty(title) ? todo.TaskTitle : title;
            todo.TaskDescription = string.IsNullOrEmpty(desc) ? todo.TaskDescription : desc;
            todo.TaskPriority = (To_Do.Priority)prio;
            todo.IsCompleted = isComp;
        }
        public void DelTask(string guid) => _toDoList.Remove(_toDoList.Find(x => x.GUID.ToString() == guid));
    }
}
