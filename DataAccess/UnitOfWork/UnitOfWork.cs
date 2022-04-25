using Clinic.Interfaces;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly MyAppContext _context;
        private IGenericRepository<T> _entity;
        public UnitOfWork(MyAppContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
