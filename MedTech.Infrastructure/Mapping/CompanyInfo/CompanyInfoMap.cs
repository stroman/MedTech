using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Domain.CompanyInfo;

namespace MedTech.Infrastructure.Mapping.CompanyInfo
{
    public class CompanyInfoMap : EntityTypeConfiguration<MedTech.Core.Domain.CompanyInfo.CompanyInfo>
    {
        public CompanyInfoMap()
        {
            this.ToTable("CompanyInfo");


            this.HasKey(ci => ci.Id);
            this.Property(ci => ci.Name).IsRequired().HasMaxLength(256);
            this.Property(ci => ci.Description).IsOptional().HasMaxLength(40000);
            this.Property(ci => ci.Address).IsRequired().HasMaxLength(1000);
            
        }
    }
}
