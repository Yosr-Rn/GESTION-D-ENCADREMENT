using Microsoft.AspNetCore.Mvc;
using GestionEtudiant.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using GestionEtudiant.Models;

namespace GestionEtudiant.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class TeacherController : Controller
    {
        readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        [AllowAnonymous]
        // GET: TeacherController
        public ActionResult Index()
        {
            return View(teacherRepository.GetAll());
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            var teacher = teacherRepository.GetById(id);
            return View(teacher);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher t)
        {
            try
            {
                teacherRepository.Add(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = teacherRepository.GetById(id);
            return View(teacher);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher t)
        {
            try
            {
                teacherRepository.Edit(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            var teacher = teacherRepository.GetById(id);
            return View(teacher);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher t)
        {
            try
            {
                teacherRepository.Delete(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
