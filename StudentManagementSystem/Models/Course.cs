using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseCode { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        // For JOIN query
        public string DepartmentName { get; set; }
    }
}