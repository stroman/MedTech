using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.Categories;

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
        #endregion

        #region Helper methods
        #endregion
    }
}
