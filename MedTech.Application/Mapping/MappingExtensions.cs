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
    public static class MappingExtensions
    {
        #region Category
        public static CategoryDto ToDto(this Category entity)
        {
            return Mapper.Map<Category, CategoryDto>(entity);
        }

        public static Category ToEntity(this CategoryDto dto)
        {
            return Mapper.Map<CategoryDto, Category>(dto);
        }

        public static Category ToEntity(this CategoryDto dto, Category destination)
        {
            return Mapper.Map(dto, destination);
        }
        #endregion
    }
}
