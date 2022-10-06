namespace Todo_App.Model
{
    public record To_Do
    {
        public Guid GUID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Created { get; init; }
        public enum Priority { Low, Normal, High }
        public Priority TaskPriority { get; set; }
        public bool IsCompleted { get; set; }
        public To_Do(Priority priority, string tasktitle, string description, DateTime Create)
        {
            TaskTitle = tasktitle;
            TaskDescription = description;
            Created = Create;
            GUID = Guid.NewGuid();
            TaskPriority = priority;
            IsCompleted = false;
        }

        public To_Do() { }
    }
}
