using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWork.Data
{
    public interface IUniOfWork
    {
        void Commit();

        void Rollback();
    }


    public class UniOfWork : IUniOfWork
    {
        private readonly DataContext _context;
        public UniOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
           
        }
    }
}
