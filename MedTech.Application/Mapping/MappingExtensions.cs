﻿
using AutoMapper;
using MedTech.Core.Domain.Categories;
using MedTech.Application.DTO.Categories;
using MedTech.Core.Domain.CompanyInfo;
using MedTech.Application.DTO.CompanyInfo;
using MedTech.Core.Domain.Membership;
using MedTech.Application.DTO.Membership;

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

        #region CompanyInfo
        public static CompanyInfoDto ToDto(this CompanyInfo entity)
        {
            return Mapper.Map<CompanyInfo, CompanyInfoDto>(entity);
        }

        public static CompanyInfo ToEntity(this CompanyInfoDto dto)
        {
            return Mapper.Map<CompanyInfoDto, CompanyInfo>(dto);
        }

        public static CompanyInfo ToEntity(this CompanyInfoDto dto, CompanyInfo destination)
        {
            return Mapper.Map(dto, destination);
        }
        #endregion

        #region Membership
        public static UserDto ToDto(this User entity)
        {
            return Mapper.Map<User, UserDto>(entity);
        }

        public static User ToEntity(this UserDto dto)
        {
            return Mapper.Map<UserDto, User>(dto);
        }

        public static User ToEntity(this UserDto dto, User destination)
        {
            return Mapper.Map(dto, destination);
        }
        #endregion
    }
}
