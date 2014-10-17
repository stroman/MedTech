using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using MedTech.Core.Domain.Membership;

namespace MedTech.Infrastructure.Mapping.Membership
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Role");
            this.HasKey(r => r.Id);
            this.Property(r => r.Name).IsRequired();
        }
    }
}
