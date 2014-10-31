using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Core.Helpers
{
    /// <summary>
    /// Help to get json data from ng-table
    /// </summary>
    public class RequestFilter
    {
        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Count per page
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Filter dictionary
        /// </summary>
        public IDictionary<string, string> Filter { get; set; }
        /// <summary>
        /// Sorting dictiondry
        /// </summary>
        public IDictionary<string, string> Sorting { get; set; }
    }
}
