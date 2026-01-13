using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProject.Data;
using PracticeProject.ViewModels.Tasks;

namespace PracticeProject.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskViewModel> GetAll(
            string userId,
            int? projectId = null,
            PriorityType? priority = null,
            StatusType? status = null)
            {
                var query = _context.Tasks
                    .Where(t => t.UserId == userId);

                if (projectId.HasValue)
                    query = query.Where(t => t.ProjectId == projectId);

                if (priority.HasValue)
                    query = query.Where(t => t.Priority == priority);

                if (status.HasValue)
                    query = query.Where(t => t.Status == status);

                return query
                    .Select(t => new TaskViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        DueDate = t.DueDate,
                        Priority = t.Priority,
                        Status = t.Status,
                        ProjectName = t.Project.Title
                    })
                    .ToList();
        }

        public IEnumerable<SelectListItem> GetUserProjects(string userId)
        {
            return _context.Projects
                .Where(p => p.UserId == userId)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Title
                })
                .ToList();
        }

        public TaskViewModel? GetById(int id, string userId)
        {
            return _context.Tasks
                .Where(t => t.Id == id && t.UserId == userId)
                .Select(t => new TaskViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    Status = t.Status,
                    ProjectId = t.ProjectId
                })
                .FirstOrDefault();
        }

        public void Create(TaskViewModel model, string userId)
        {
            var task = new Data.Task
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Status = model.Status,
                ProjectId = model.ProjectId,
                UserId = userId
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskViewModel model, string userId)
        {
            var task = _context.Tasks
                .FirstOrDefault(t => t.Id == model.Id && t.UserId == userId);

            if (task == null) return;

            task.Title = model.Title;
            task.Description = model.Description;
            task.DueDate = model.DueDate;
            task.Priority = model.Priority;
            task.Status = model.Status;
            task.ProjectId = model.ProjectId;

            _context.SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            var task = _context.Tasks
                .FirstOrDefault(t => t.Id == id && t.UserId == userId);

            if (task == null) return;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
