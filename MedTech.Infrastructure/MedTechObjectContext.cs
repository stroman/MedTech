using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using MedTech.Core;

namespace MedTech.Infrastructure
{
    /// <summary>
    /// Object context
    /// </summary>
    public class MedTechObjectContext : DbContext, IDbContext
    {
        public MedTechObjectContext(): base()
        {
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, 
        /// but before the model has been locked down and used to initialize the context. 
        /// The default implementation of this method does nothing, but it can be overridden in a derived class such that the model can be further configured before it is locked down. 
        /// </summary>
        /// <param name="modelBuilder"> DbModelBuilder is used to map CLR classes to a database schema</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            //...or do it manually below. For example, modelBuilder.Configurations.Add(new LanguageMap());
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(type => !String.IsNullOrEmpty(type.Namespace))
                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configInstance);
            }

            //Sets the database initialization strategy. 
            //MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration> is an implementation of IDatabaseInitializer
            //that will use Code First Migrations to update the database to the latest migration.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MedTechObjectContext, MedTechMigrationsConfiguration>());

            base.OnModelCreating(modelBuilder);
        }
    }    
}
