using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
