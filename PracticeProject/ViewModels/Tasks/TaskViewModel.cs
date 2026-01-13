using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProject.Data;
using PracticeProject.Validation;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.ViewModels.Tasks
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string ProjectName { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [DateAfterToday]
        public DateTime DueDate { get; set; }

        [Required]
        public PriorityType Priority { get; set; }

        [Required]
        public StatusType Status { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public IEnumerable<SelectListItem>? Projects { get; set; }
    }
}
