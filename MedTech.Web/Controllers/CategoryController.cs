using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Application.Services.Categories;
using MedTech.Application.DTO.Categories;

namespace MedTech.Web.Controllers
{
    public class CategoryController : ApiController
    {
        #region Fields

        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region Methods CRUD
        public CategoryDto GetTestCategory()
        {
            return _categoryService.GetAllCategory().FirstOrDefault();            
        }

        #endregion

        #region Helper methods
        #endregion
    }
}
