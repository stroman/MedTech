using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedTech.Core;
using MedTech.Core.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MedTech.Infrastructure
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        public virtual T GetById(long id)
        {
            return this.Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if(entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                CreateDbException(dbEx);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                CreateDbException(dbEx);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                CreateDbException(dbEx);
            }
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }        

        #region Helper Methods
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        private void CreateDbException(DbEntityValidationException ex)
        {
            var msg = string.Empty;

            foreach (var validationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                }
            }
            var fail = new Exception(msg, ex);
            //Debug.WriteLine(fail.Message, fail);
            throw fail;
        }
        #endregion
    }
}
