using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.Data;
using PracticeProject.Services.Tasks;
using PracticeProject.ViewModels.Tasks;

namespace PracticeProject.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _service;
        private readonly UserManager<User> _userManager;

        public TasksController(
            ITaskService service,
            UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public IActionResult Index(TaskFilterViewModel filter)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null) return Unauthorized();

            var tasks = _service.GetAll(
                userId,
                filter.ProjectId,
                filter.Priority,
                filter.Status);

            filter.Projects = _service.GetUserProjects(userId);

            ViewBag.Filter = filter;
            return View(tasks);
        }

        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null) return Unauthorized();

            var model = new TaskViewModel
            {
                Projects = _service.GetUserProjects(userId)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                model.Projects = _service.GetUserProjects(userId!);
                return View(model);
            }

            var userIdFinal = _userManager.GetUserId(User);
            if (userIdFinal == null) return Unauthorized();

            _service.Create(model, userIdFinal);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var task = _service.GetById(id, userId);

            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var task = _service.GetById(id, userId);

            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            _service.Update(model, userId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var task = _service.GetById(id, userId);

            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel model)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            _service.Delete(model.Id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
