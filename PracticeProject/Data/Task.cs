namespace PracticeProject.Data
{
    public enum PriorityType { low, medium, high }
    public enum StatusType { new_task, in_progress, completed_task}

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityType Priority { get; set; }
        public StatusType Status { get; set; }

        //Foreig key to Projects table
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        //Foreign key to Users table
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
