using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MedTech.Core.Domain.Categories;
using MedTech.Core.Domain.CompanyInfo;
using MedTech.Core.Domain.Membership;
using MedTech.Application.DTO.Categories;
using MedTech.Application.DTO.CompanyInfo;
using MedTech.Application.DTO.Membership;

namespace MedTech.Application.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();

            Mapper.CreateMap<CompanyInfo, CompanyInfoDto>();
            Mapper.CreateMap<CompanyInfoDto, CompanyInfo>();

            Mapper.CreateMap<User, UserDto>().ForMember(dto => dto.RoleName, dto => dto.MapFrom( u => u.Role.Name));
            Mapper.CreateMap<UserDto, User>();
        }
    }
}
