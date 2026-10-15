using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository repository;

        public StudentController()
        {
            repository = new StudentRepository();
        }

        public ActionResult Index()
        {
            StudentViewModel model = new StudentViewModel();
            model.Students = repository.GetAllStudents();

            return View(model);
        }

        // =========================
        // CREATE - GET
        // =========================

        [HttpGet]
        public ActionResult AddStudent()
        {
            StudentViewModel model = new StudentViewModel();

            model.Student = new Student();

            model.Departments = repository
                .GetAllDepartments()
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                })
                .ToList();

            return View(model);
        }


        // =========================
        // CREATE - POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                repository.InsertStudent(model.Student);

                return RedirectToAction("Index");
            }

            model.Departments = repository
                .GetAllDepartments()
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                })
                .ToList();

            return View(model);
        }


        // =========================
        // EDIT - GET
        // =========================

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            Student student = repository.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            StudentViewModel model = new StudentViewModel();

            model.Student = student;

            model.Departments = repository
                .GetAllDepartments()
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName,
                    Selected = d.DepartmentId == student.DepartmentId
                })
                .ToList();

            return View(model);
        }


        // =========================
        // EDIT - POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateStudent(model.Student);

                return RedirectToAction("Index");
            }

            model.Departments = repository
            .GetAllDepartments()
            .Select(d => new SelectListItem
            {
                Value = d.DepartmentId.ToString(),
                Text = d.DepartmentName,
                Selected = d.DepartmentId == model.Student.DepartmentId
            })
            .ToList();

            return View(model);
        }


        // =========================
        // DETAILS
        // =========================

        [HttpGet]
        public ActionResult StudentDetails(int id)
        {
            Student student = repository.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        // =========================
        // DELETE - GET
        // =========================

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            Student student = repository.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        // =========================
        // DELETE - POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int StudentId)
        {
            repository.DeleteStudent(StudentId);

            return RedirectToAction("Index");
        }
    }
}