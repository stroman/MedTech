using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTech.Application.DTO.CompanyInfo
{
    public class ContactDto
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public int ContactType { get; set; }

        public long CompanyId { get; set; }
    }
}
