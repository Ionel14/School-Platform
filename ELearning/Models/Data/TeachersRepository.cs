using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class TeachersRepository : RepositoryBase<Teacher>
    {
        private readonly SchoolDbContext dbContext;

        public TeachersRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Teacher FindByPersonId(int Id)
        {
            return GetRecords().FirstOrDefault((teacher) => teacher.Person.Id == Id);
        }
    }
}
