using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MedTech.Core.Domain.CompanyInfo;

namespace MedTech.Infrastructure.Mapping.CompanyInfo
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            this.ToTable("Contact");

            this.HasRequired(c => c.CompanyInfo)
                .WithMany(ci => ci.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .WillCascadeOnDelete(true);

            this.HasKey(c => c.Id);
            this.Property(c => c.Value).IsRequired().HasMaxLength(128);
        }
    }
}
