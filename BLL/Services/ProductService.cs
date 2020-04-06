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
    public class ProductService : IService<ProductDTO>
    {
        private UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<ProductDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_uow.ProductRepository.GetAll());
        }

        public IEnumerable<string> GetAllNames()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Product, ProductDTO>()).CreateMapper();
            var products = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_uow.ProductRepository.GetAll());

            var list = new List<string>();
            foreach (var x in products)
                list.Add(x.Name);
            return list;
        }
        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<Product, ProductDTO>(_uow.ProductRepository.GetById(id)).Name;
        }
        public IEnumerable<string> GetProductsByCategory(int categoryId)    //1 query
        {
            var products = GetAll();

            var result = products.Where(x => x.CategoryId == categoryId);

            var list = new List<string>();
            foreach (var x in result)
                list.Add(x.Name);
            return list;
        }
        public IEnumerable<string> GetProductsBySupplier(int supplierId)   //3 query
        {
            var products = GetAll();

            var result = products.Where(x => x.SupplierId == supplierId);

            var list = new List<string>();
            foreach (var x in result)
                list.Add(x.Name);
            return list;
        }
    }
}
