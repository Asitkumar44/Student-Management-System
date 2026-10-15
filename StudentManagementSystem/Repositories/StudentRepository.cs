using Dapper;
using StudentManagementSystem.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace StudentManagementSystem.Repositories
{
    public class StudentRepository
    {
        private readonly string connectionString;

        public StudentRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        // GET ALL STUDENTS
        public List<Student> GetAllStudents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>(
                    "sp_GetAllStudents",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        // GET STUDENT BY ID
        public Student GetStudentById(int studentId)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@StudentId", studentId);

                return connection.QueryFirstOrDefault<Student>(
                    "sp_GetStudentById",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        // INSERT STUDENT
        public void InsertStudent(Student student)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@StudentName", student.StudentName);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DateOfBirth", student.DateOfBirth);
                parameters.Add("@Email", student.Email);
                parameters.Add("@Phone", student.Phone);
                parameters.Add("@Address", student.Address);
                parameters.Add("@AdmissionDate", student.AdmissionDate);
                parameters.Add("@DepartmentId", student.DepartmentId);

                connection.Execute(
                    "sp_InsertStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        // UPDATE STUDENT
        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@StudentId", student.StudentId);
                parameters.Add("@StudentName", student.StudentName);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DateOfBirth", student.DateOfBirth);
                parameters.Add("@Email", student.Email);
                parameters.Add("@Phone", student.Phone);
                parameters.Add("@Address", student.Address);
                parameters.Add("@AdmissionDate", student.AdmissionDate);
                parameters.Add("@DepartmentId", student.DepartmentId);

                connection.Execute(
                    "sp_UpdateStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }


        // DELETE STUDENT
        public void DeleteStudent(int studentId)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@StudentId", studentId);

                connection.Execute(
                    "sp_DeleteStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        // GET ALL DEPARTMENTS
        public List<Department> GetAllDepartments()
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                return connection.Query<Department>(
                    "sp_GetAllDepartments",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
    }
}