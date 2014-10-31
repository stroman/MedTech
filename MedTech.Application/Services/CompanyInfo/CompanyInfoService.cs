using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Data;
using MedTech.Core.Domain.CompanyInfo;
using MedTech.Application.DTO.CompanyInfo;
using MedTech.Application.Mapping;

namespace MedTech.Application.Services.CompanyInfo
{
    /// <summary>
    /// Company information service
    /// </summary>
    public class CompanyInfoService : ICompanyInfoService
    {
        #region Fields

        private readonly IRepository<MedTech.Core.Domain.CompanyInfo.CompanyInfo> _companyInfoRepository;
        #endregion

        #region Ctor
        public CompanyInfoService(IRepository<MedTech.Core.Domain.CompanyInfo.CompanyInfo> companyInfoRepository)
        {
            _companyInfoRepository = companyInfoRepository;
        }
        #endregion

        #region Methods
        public CompanyInfoDto GetCompanyInfo()
        {            
            return GetActualCompanyInfo().ToDto();
        }
        #endregion

        #region Helper methods
        private MedTech.Core.Domain.CompanyInfo.CompanyInfo GetActualCompanyInfo()
        {
            return _companyInfoRepository.Table.First();
        }
        #endregion
    }
}
