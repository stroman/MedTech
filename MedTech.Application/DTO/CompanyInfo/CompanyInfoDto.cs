using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Application.DTO.CompanyInfo
{
    public class CompanyInfoDto
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }        
        public string Address { get; set; }
        public string UrlAddress { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
    }
}
