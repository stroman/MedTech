using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: BaseEntity
    {
        T GetById(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
