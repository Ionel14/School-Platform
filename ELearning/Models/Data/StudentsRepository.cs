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
    internal class StudentsRepository : RepositoryBase<Student>
    {
        private readonly SchoolDbContext dbContext;

        public StudentsRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public Student FindByEmail(string Email)
        {
            return GetRecords().FirstOrDefault((student) => student.Person.Email == Email);
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@Id", student.Id);

                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
