using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProject.Data;

namespace PracticeProject.ViewModels.Tasks
{
    public class TaskFilterViewModel
    {
        public int? ProjectId { get; set; }
        public PriorityType? Priority { get; set; }
        public StatusType? Status { get; set; }

        public IEnumerable<SelectListItem>? Projects { get; set; }
    }
}
