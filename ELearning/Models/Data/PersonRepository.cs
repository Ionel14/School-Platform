using ELearning.Helpers;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class PersonRepository : RepositoryBase<Person>
    {
        private readonly SchoolDbContext dbContext;

        public PersonRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Person FindByEmail(string email)
        {
            return GetRecords().FirstOrDefault((person) =>  person.Email == email);
        }

        public void DeletePerson(Person person)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@Id", person.Id);

                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
