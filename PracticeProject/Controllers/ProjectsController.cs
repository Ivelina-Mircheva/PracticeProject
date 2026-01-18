using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.Data;
using PracticeProject.Services.Projects;
using PracticeProject.ViewModels.Projects;

namespace PracticeProject.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _service;
        private readonly UserManager<User> _userManager;

        public ProjectsController(
            IProjectService service,
            UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var user = _userManager.GetUserId(User);

            if (user == null)
                return Unauthorized();

            var projects = _service.GetAll(user);
            return View(projects);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            _service.Create(model, userId);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var project = _service.GetById(id, userId);

            if (project == null)
                return NotFound();

            return View(project);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            var project = _service.GetById(id, userId);

            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(ProjectViewModel model)
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

            var project = _service.GetById(id, userId);

            if (project == null)
                return NotFound();

            return View(project);
        }
        [HttpPost]
        public IActionResult Delete(ProjectViewModel model)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return Unauthorized();

            _service.Delete(model.Id, userId);
            return RedirectToAction(nameof(Index));
        }


    }
}
