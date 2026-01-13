using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProject.Data;
using PracticeProject.ViewModels.Tasks;

namespace PracticeProject.Services.Tasks
{
    public interface ITaskService
    {
        IEnumerable<TaskViewModel> GetAll(string userId,
    int? projectId,
    PriorityType? priority,
    StatusType? status);
        IEnumerable<SelectListItem> GetUserProjects(string userId);
        TaskViewModel? GetById(int id, string userId);

        void Create(TaskViewModel model, string userId);
        void Update(TaskViewModel model, string userId);
        void Delete(int id, string userId);
    }
}
