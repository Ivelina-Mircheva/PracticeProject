using PracticeProject.ViewModels.Projects;

namespace PracticeProject.Services.Projects
{
    public interface IProjectService
    {
        IEnumerable<ProjectViewModel> GetAll(string userId);
        ProjectViewModel? GetById(int id, string userId);

        void Create(ProjectViewModel model, string userId);
        void Update(ProjectViewModel model, string userId);
        void Delete(int id, string userId);
    }
}
