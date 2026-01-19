using PracticeProject.ViewModels.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.ViewModels.Projects
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        public List<TaskViewModel> Tasks { get; set; } = new();
    }
}
