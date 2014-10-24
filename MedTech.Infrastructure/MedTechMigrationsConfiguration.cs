using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Domain.Membership;
using MedTech.Core.Domain.CompanyInfo;

namespace MedTech.Infrastructure
{
    public class MedTechMigrationsConfiguration : DbMigrationsConfiguration<MedTechObjectContext>
    {
        public MedTechMigrationsConfiguration()
        {
            //Gets or sets a value indicating if automatic migrations can be used when migrating the database.
            AutomaticMigrationsEnabled = true;
            //Gets or sets a value indicating if data loss is acceptable during automatic migration. 
            //If set to false an exception will be thrown if data loss may occur as part of an automatic migration.
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MedTechObjectContext context)
        {
            //context.Set<Role>().Add(new Role { Id = (long)RoleEnum.Admin, Name = Enum.GetName(typeof(RoleEnum), (long)RoleEnum.Admin) });
            //context.Set<Role>().Add(new Role { Id = (long)RoleEnum.Manager, Name = Enum.GetName(typeof(RoleEnum), (long)RoleEnum.Manager) });
            //context.Set<User>().Add(new User
            //{
            //    Id = 1,
            //    FirstName = "Admin",
            //    LastName = "Admin",
            //    Email = "admin@medtech.com",

            //});

            if (!context.Set<CompanyInfo>().Any())
            {
                context.Set<CompanyInfo>().Add(new CompanyInfo
                {
                    Id = 1,
                    Name = "MedTech Company",
                    Description = "The best company.",
                    Address = "Minsk"
                });
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
