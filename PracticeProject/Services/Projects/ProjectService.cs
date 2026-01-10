using PracticeProject.Data;
using PracticeProject.ViewModels.Projects;

namespace PracticeProject.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectViewModel> GetAll(string userId)
        {
            return _context.Projects
                .Where(p => p.UserId == userId)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description
                })
                .ToList();
        }

        public ProjectViewModel? GetById(int id, string userId)
        {
            return _context.Projects
                .Where(p => p.Id == id && p.UserId == userId)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description
                })
                .FirstOrDefault();
        }

        public void Create(ProjectViewModel model, string userId)
        {
            var project = new Project
            {
                Title = model.Title,
                Description = model.Description,
                UserId = userId
            };

            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Update(ProjectViewModel model, string userId)
        {
            var project = _context.Projects
                .FirstOrDefault(p => p.Id == model.Id && p.UserId == userId);

            if (project == null) return;

            project.Title = model.Title;
            project.Description = model.Description;

            _context.SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            var project = _context.Projects
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (project == null) return;

            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }

}
