using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentManagementSystem.Models.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<Student> Students { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}