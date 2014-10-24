using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Domain.CompanyInfo
{
    /// <summary>
    /// Represents a contact for company information
    /// </summary>
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the type of contact
        /// </summary>
        public int ContactType { get; set; }

        /// <summary>
        /// Gets or sets the company identifier
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company
        /// </summary>
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
}
