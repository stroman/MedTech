using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedTech.Web.Models
{
    public class ResponseModel
    {
        public int TotalCount { get; set; }        
        public object Rows { get; set; }
    }
}