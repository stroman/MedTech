using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.Categories;

using MedTech.Application.DTO.Categories;
using MedTech.Application.Mapping;

namespace MedTech.Application.Services.Categories
{
    /// <summary>
    /// Category Service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly IRepository<Category> _categoryRepository;
        #endregion

        #region Ctor
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Methods
        public List<CategoryDto> GetAllCategory()
        {            
            return GetActualCategories().Select(c => c.ToDto()).ToList();
        }
        #endregion

        #region Helper methods
        private IEnumerable<Category> GetActualCategories()
        {
            return _categoryRepository.Table.AsEnumerable();
        }
        #endregion
    }
}
