using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class ThesisRepository : RepositoryBase<Thesis>
    {
        private readonly SchoolDbContext dbContext;

        public ThesisRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Thesis FindByCourse(Course course)
        {
            return GetRecords().FirstOrDefault((thesis) => thesis.Course.Name == course.Name);
        }
    }
}
