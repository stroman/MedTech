using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MedTech.Core.Domain.Categories;
using MedTech.Application.DTO.Categories;

namespace MedTech.Application.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
        }
    }
}
