using ELearning.Helpers;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class SpecializationRepository : RepositoryBase<Specialization>
    {
        private readonly SchoolDbContext dbContext;

        public SpecializationRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public Specialization FindByName(string name)
        {
            return GetRecords().FirstOrDefault((spec) => spec.Name == name);
        }

        public void InsertSpecialization(string specializationName)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Name", specializationName);

                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            //_dbContext.Database.ExecuteSqlCommand("EXEC dbo.InsertSpecialization @Name = @p0",
            //specializationName);
        }
        
        public void UpdateSpecialization(string specializationName, int Id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Name", specializationName);
                SqlParameter paramId = new SqlParameter("@Id", Id);

                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            //_dbContext.Database.ExecuteSqlCommand("EXEC dbo.InsertSpecialization @Name = @p0",
            //specializationName);

        }

        public List<Specialization> GetAllSpecializations()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecializations", con);
                List<Specialization> result = new List<Specialization>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Specialization()
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@Id", specialization.Id);

                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
