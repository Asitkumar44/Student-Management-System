using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public int DepartmentId { get; set; }

        // For JOIN display
        public string DepartmentName { get; set; }
    }
}