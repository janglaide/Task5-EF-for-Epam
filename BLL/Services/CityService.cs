using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CityService : IService<CityDTO>
    {
        private UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<CityDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<City, CityDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(_uow.CityRepository.GetAll());
        }

        public IEnumerable<string> GetAllNames()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<City, CityDTO>()).CreateMapper();
            var cities = mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(_uow.CityRepository.GetAll());

            var list = new List<string>();
            foreach (var x in cities)
                list.Add(x.Name);
            return list;
        }
        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<City, CityDTO>()).CreateMapper();
            return mapper.Map<City, CityDTO>(_uow.CityRepository.GetById(id)).Name;
        }
    }
}
