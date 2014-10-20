using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Domain.CompanyInfo
{
    /// <summary>
    /// Information about company
    /// </summary>
    public class CompanyInfo : BaseEntity
    {
        private ICollection<Contact> _contacts;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets contacts
        /// </summary>
        public virtual ICollection<Contact> Contacts
        {
            get { return _contacts ?? (_contacts = new List<Contact>()); }
            set { _contacts = value; }
        }
    }
}
