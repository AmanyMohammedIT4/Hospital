using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContex _context;

        public UnitOfWork(ApplicationDbContex context)
        {
            _context = context;
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            return repo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
