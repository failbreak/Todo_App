namespace Todo_App.Model
{
    public class To_Do
    {
        public Guid GUID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Created { get; init; }
        public enum Priority { Low, Normal, High }
        public Priority TaskPriority { get; set; }
        public bool IsCompleted { get; set; }
        public To_Do(string tasktitle, string description )
        {
            TaskTitle = tasktitle;
            TaskDescription = description;
            Created = DateTime.Now;
            GUID = Guid.NewGuid();
            TaskPriority = Priority.Normal;
            IsCompleted = false;
        }
    }
}
