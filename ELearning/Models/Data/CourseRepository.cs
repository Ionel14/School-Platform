using ELearning.Helpers;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class CourseRepository : RepositoryBase<Course>
    {
        private readonly SchoolDbContext dbContext;

        public CourseRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Course FindByName(string name)
        {
            return GetRecords().FirstOrDefault((@Course) => @Course.Name == name);
        }

        public Course FindToGetId(Course course)
        {
            return GetRecords().First((c) => c.Name == course.Name && c.TeacherId == course.TeacherId);
        }

        public List<Course> GetAllCourses()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllCourses", con);
                List<Course> result = new List<Course>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Course()
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            TeacherId = (int)reader["TeacherId"],
                            Teacher = reader["Teacher"] as Teacher,
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        public void DeleteCourse(Course course)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@Id", course.Id);

                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
