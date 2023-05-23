using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class ClassMasterRepository : RepositoryBase<ClassMaster>
    {
        private readonly SchoolDbContext dbContext;

        public ClassMasterRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public ClassMaster FindToGetId(ClassMaster classMaster)
        {
            return GetRecords().First((cm) => cm.ClassId == classMaster.ClassId && cm.TeacherId == classMaster.TeacherId);
        }
    }
}
