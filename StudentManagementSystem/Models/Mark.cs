using System;

namespace StudentManagementSystem.Models
{
    public class Mark
    {
        public int MarkId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int Marks { get; set; }

        public string Grade { get; set; }

        public string ExamType { get; set; }

        public DateTime? ExamDate { get; set; }

        // For display
        public string StudentName { get; set; }

        public string CourseName { get; set; }
    }
}