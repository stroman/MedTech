using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Application.DTO.Categories;

namespace MedTech.Application.Services.Categories
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategory();
    }
}
