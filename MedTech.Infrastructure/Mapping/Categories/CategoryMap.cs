using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MedTech.Core.Domain.Categories;

namespace MedTech.Infrastructure.Mapping.Categories
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.Description).IsOptional();
            this.Property(c => c.ParentCategoryId).IsOptional();
            this.Property(c => c.Sequence).IsOptional();
        }
    }
}
