using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        private UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_uow.CategoryRepository.GetAll());
        }

        public IEnumerable<string> GetAllNames()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Category, CategoryDTO>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_uow.CategoryRepository.GetAll());

            var list = new List<string>();
            foreach (var x in categories)
                list.Add(x.Name);
            return list;
        }
        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(_uow.CategoryRepository.GetById(id)).Name;
        }
    }
}
