namespace Todo_App.Model
{
    public class To_Do
    {
        public string Guid { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Created { get; set; }
        public enum Priority { Low, Normal, High }
        public Priority TaskPriority { get; set; }
        public bool IsCompleted { get; set; }
        public To_Do(string tasktitle, string description, string guid )
        {
            TaskTitle = tasktitle;
            TaskDescription = description;
            Created = DateTime.Now;
            Guid = guid;
            TaskPriority = Priority.Normal;
            IsCompleted = false;
        }
    }
}
