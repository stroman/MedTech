using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedTech.Application.DTO.Categories;

namespace MedTech.Web.Api.Controllers
{
    public class CategoryController : ApiController
    {
        public CategoryDto GetCategory()
        {
            return new CategoryDto
            {
                Id = 0,
                Name = "Category1",
                Description = "Test category"
            };
        }
    }
}
