using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface IProgramRepository
    {
        List<Program> GetListProgram();
        List<Program> GetListProgramHome();
        Program GetProgramDetail(int Id);
        Program Add(Program orderModel);
        void Update(Program orderModel);
        Program Delete(int id);
        IEnumerable<Program> GetListProgramPaging(int page, int pageSize, out int totalRow);
    }
    public class ProgramRepository : IProgramRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();

        public IEnumerable<Program> GetListProgramPaging(int page, int pageSize, out int totalRow)
        {
            var query = db.Program.Where(x => x.Status == 1).ToList();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public Program Add(Program order)
        {

            db.Program.Add(order);
            db.SaveChanges();
            return order;
        }

        public Program Delete(int id)
        {
            var Program = db.Program.Find(id);
            db.Program.Remove(Program);
            db.SaveChanges();

            return Program;
        }

        public List<Program> GetListProgram()
        {
            var lst = db.Program.OrderBy(y => y.CreateDate).ToList();
            return lst;
        }

        public List<Program> GetListProgramHome()
        {
            var lst = db.Program.OrderBy(y => y.CreateDate).Where(x => x.Status == 1).Take(8).ToList();
            return lst;
        }

        public Program GetProgramDetail(int Id)
        {
            var lst = db.Program.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(Program order)
        {
            db.Program.Attach(order);
            db.Entry(order).State = EntityState.Modified;
            db.Entry(order).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
