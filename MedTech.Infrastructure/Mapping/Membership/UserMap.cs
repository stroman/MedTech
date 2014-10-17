using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using MedTech.Core.Domain.Membership;

namespace MedTech.Infrastructure.Mapping.Membership
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            
            this.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(x => x.ToTable("UserRole"));

            this.HasKey(u => u.Id);
            this.Property(u => u.FirstName).IsRequired();
            this.Property(u => u.LastName).IsRequired();
            this.Property(u => u.Email).IsRequired();
            this.Property(u => u.Password).IsRequired();
            this.Property(u => u.LastLoginDate).IsOptional();
        }
    }
}
