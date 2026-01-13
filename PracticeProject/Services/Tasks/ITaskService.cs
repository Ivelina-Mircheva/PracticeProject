using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProject.ViewModels.Tasks;

namespace PracticeProject.Services.Tasks
{
    public interface ITaskService
    {
        IEnumerable<TaskViewModel> GetAll(string userId);
        IEnumerable<SelectListItem> GetUserProjects(string userId);
        TaskViewModel? GetById(int id, string userId);

        void Create(TaskViewModel model, string userId);
        void Update(TaskViewModel model, string userId);
        void Delete(int id, string userId);
    }
}
