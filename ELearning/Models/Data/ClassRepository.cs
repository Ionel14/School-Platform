using ELearning.Helpers;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class ClassRepository : RepositoryBase<Class>
    {
        private readonly SchoolDbContext dbContext;

        public ClassRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Class FindByName(string name)
        {
            return GetRecords().FirstOrDefault((clasa) => clasa.Name == name);
        }

        public List<Class> GetAllCourses()
        {
            return dbContext.Classes.Include("Courses").Include("Theses").ToList();
        }

        public void UpdateClass(Class @class)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@Id", @class.Id);
                SqlParameter paramNume = new SqlParameter("@Name", @class.Name);
                SqlParameter paramIdSpecializare = new SqlParameter("@SpecializationId", @class.SpecializationId);

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramIdSpecializare);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            //_dbContext.Database.ExecuteSqlCommand(
            //"EXEC dbo.UpdateClass @Id, @Name, @SpecializationId",
            //new SqlParameter("@Id", @class.Id),
            //new SqlParameter("@Name", @class.Name),
            //new SqlParameter("@SpecializationId", @class.SpecializationId)
            //);
        }
    }
}
