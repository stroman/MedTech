using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MedTech.Core.Domain.Categories;
using MedTech.Core.Domain.CompanyInfo;
using MedTech.Core.Domain.Membership;
using MedTech.Core.Domain.TextResources;
using MedTech.Application.DTO.Categories;
using MedTech.Application.DTO.CompanyInfo;
using MedTech.Application.DTO.Membership;
using MedTech.Application.DTO.TextResources;

namespace MedTech.Application.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();

            Mapper.CreateMap<CompanyInfo, CompanyInfoDto>();
            Mapper.CreateMap<CompanyInfoDto, CompanyInfo>().ForMember(dest => dest.Contacts, mo => mo.Ignore());

            Mapper.CreateMap<Contact, ContactDto>();
            Mapper.CreateMap<ContactDto, Contact>();

            Mapper.CreateMap<User, UserDto>().ForMember(dest => dest.RoleName, mo => mo.MapFrom(u => u.Role.Name));
            Mapper.CreateMap<UserDto, User>();

            //Mapper.CreateMap<Role, RoleDto>();
            //Mapper.CreateMap<RoleDto, Role>();

            Mapper.CreateMap<TextResource, TextResourceDto>();
            Mapper.CreateMap<TextResourceDto, TextResource>();
        }
    }
}
