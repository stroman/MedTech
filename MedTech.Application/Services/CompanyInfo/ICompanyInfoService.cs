using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedTech.Application.DTO.CompanyInfo;

namespace MedTech.Application.Services.CompanyInfo
{
    public interface ICompanyInfoService
    {
        CompanyInfoDto GetCompanyInfo();
        void UpdateCompanyInfo(CompanyInfoDto companyInfo);
    }
}
