using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BLL.Services
{
    public class SupplierService : IService<SupplierDTO>
    {
        private UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<SupplierDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(_uow.SupplierRepository.GetAll());
        }

        public IEnumerable<string> GetAllNames()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            var suppliers = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(_uow.SupplierRepository.GetAll());

            var list = new List<string>();
            foreach (var x in suppliers)
                list.Add(x.Name);
            return list;
        }
        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<Supplier, SupplierDTO>(_uow.SupplierRepository.GetById(id)).Name;
        }
        public IEnumerable<string> GetSuppliersByCategory(int categoryId)    //2 query
        {
            var categoryService = new CategoryService();
            var categories = categoryService.GetAll();

            var productService = new ProductService();
            var products = productService.GetAll();

            var suppliers = GetAll();

            var result = suppliers
                .Join(products, s => s.Id, p => p.SupplierId,
                (s, p) => new { catId = p.CategoryId, supName = s.Name })
                .Join(categories, sp => sp.catId, c => c.Id,
                (sp, c) => new { categId = c.Id, supplierName = sp.supName })
                .Where(x => x.categId == categoryId).Distinct();

            var list = new List<string>();
            foreach (var x in result)
                list.Add(x.supplierName);
            return list;
        }
        public IEnumerable<string> GetSuppliersByCity(int cityId) // 4 query
        {
            var suppliers = GetAll();

            var result = suppliers.Where(x => x.CityId == cityId);

            var list = new List<string>();
            foreach (var x in result)
                list.Add(x.Name);
            return list;
        }
    }
}
