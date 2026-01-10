using System.ComponentModel.DataAnnotations;

namespace PracticeProject.ViewModels.Projects
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на проекта е задължително")]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
