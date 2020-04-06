using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private MyDBContext _context;
        public CityRepository(MyDBContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetAll()
        {
            return _context.Cities;
        }

        public City GetById(int id)
        {
            return _context.Cities.Find(id);
        }
    }
}
