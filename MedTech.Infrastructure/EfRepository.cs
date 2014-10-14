using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedTech.Core;
using MedTech.Core.Data;

namespace MedTech.Infrastructure
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
    }
}
