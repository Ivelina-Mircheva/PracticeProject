namespace PracticeProject.Data
{
        public class Project
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

            //Foreign key to Users table
            public string UserId { get; set; }
            public User User { get; set; }
            public ICollection<Task> Tasks { get; set; } = new List<Task>(); //connection to Tasks table
        }
}
