using System;

namespace StudentManagementSystem.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string Status { get; set; }

        // For display
        public string StudentName { get; set; }

        public string CourseName { get; set; }
    }
}