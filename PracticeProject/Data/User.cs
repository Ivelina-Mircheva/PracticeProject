using Microsoft.AspNetCore.Identity;

namespace PracticeProject.Data
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Project> Projects { get; set; } = new List<Project>(); //connection to Projects table
        public ICollection<Task> Tasks { get; set; } = new List<Task>(); //connection to Tasks table
    }
}
