using ELearning.Helpers;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class GradeThesisRepository
    {
        private readonly SchoolDbContext _dbContext;
        private readonly DbSet<GradeThesis> _dbSet;
        public GradeThesisRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<GradeThesis>();
        }

        public void Insert(GradeThesis gradeThesis)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertGradeThesis", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramGradeId = new SqlParameter("@GradeId", gradeThesis.GradeId);
                SqlParameter paramThesisId = new SqlParameter("@ThesisId", gradeThesis.ThesisId);

                cmd.Parameters.Add(paramGradeId);
                cmd.Parameters.Add(paramThesisId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            //var gradeIdParam = new SqlParameter("@GradeId", gradeThesis.GradeId);
            //var thesisIdParam = new SqlParameter("@ThesisId", gradeThesis.ThesisId);

            //_dbContext.Database.ExecuteSqlCommand("EXEC dbo.InsertGradeThesis @GradeId, @ThesisId",
            //    gradeIdParam,
            //    thesisIdParam);
        }

        public void Update(GradeThesis entity)
        {
            _dbSet.AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        ///     This method will actually remove the row from the database.
        /// </summary>
        public void Remove(GradeThesis entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<GradeThesis> GetAll()
        {
            return GetRecords().ToList();
        }

        public bool Any(Func<GradeThesis, bool> expression)
        {
            return GetRecords().Any(expression);
        }

        protected IQueryable<GradeThesis> GetRecords()
        {
            return _dbSet.AsQueryable<GradeThesis>();
        }

        //public Thesis FindByCourse(Course course)
        //{
        //    return GetRecords().FirstOrDefault((thesis) => thesis.Name == name);
        //}
    }
}
