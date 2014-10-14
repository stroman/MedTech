using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Domain.Categories
{
    /// <summary>
    /// Represents a category
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parent category identifier
        /// </summary>
        public long? ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the sequence in the list of categories
        /// </summary>
        public long? Sequence { get; set; }
    }
}
