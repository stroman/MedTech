using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Application.DTO.Categories
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }        
        public long? ParentCategoryId { get; set; }
        public long? Sequence { get; set; }
    }
}
