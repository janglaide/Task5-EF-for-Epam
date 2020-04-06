using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private MyDBContext _context;
        public SupplierRepository(MyDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers;
        }
        public Supplier GetById(int id)
        {
            return _context.Suppliers.Find(id);
        }
    }
}
