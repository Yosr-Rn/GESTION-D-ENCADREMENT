using GestionEtudiant.Models;
using GestionEtudiant.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionEtudiant.Controllers
{


    [Authorize(Roles = "Admin,Manager")]
    public class StudentController : Controller
    {
        readonly IStudentRepository studentrepository;
        readonly ISchoolRepository schoolrepository;
        readonly ITeacherRepository teacherRepository; 
        public StudentController(IStudentRepository studentrepository, ISchoolRepository schoolrepository, ITeacherRepository teacherRepository)
        {
            this.studentrepository = studentrepository;
            this.schoolrepository = schoolrepository;
            this.teacherRepository = teacherRepository;
        }
        // GET: StudentController
 
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "TeacherName");
            return View(studentrepository.GetAll());
        }
        public ActionResult Search(string name, int? schoolid, int? teacherid)
        {
            var result = studentrepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = studentrepository.FindByName(name);
            else
            if (schoolid != null)
                result = studentrepository.GetStudentsBySchoolID(schoolid); 
            else
            if (teacherid != null)
                result = studentrepository.GetStudentsByTeacherID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "TeacherName");
            return View("Index", result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studentrepository.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "TeacherName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName", s.SchoolID);
                ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "TeacherName",s.TeacherID);
                studentrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "TeacherName");
            return View(studentrepository.GetById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student s)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
                ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "TeacherName");
                studentrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(studentrepository.GetById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student s)
        {
            try
            {
                studentrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
