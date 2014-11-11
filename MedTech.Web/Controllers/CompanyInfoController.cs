using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Application.Services.CompanyInfo;
using MedTech.Application.DTO.CompanyInfo;
using Newtonsoft.Json;

namespace MedTech.Web.Controllers
{
    public class CompanyInfoController : ApiController
    {
        #region Fields

        private readonly ICompanyInfoService _companyInfoService;

        #endregion

        #region Ctor
        public CompanyInfoController(ICompanyInfoService companyInfoService)
        {
            _companyInfoService = companyInfoService;
        }
        #endregion

        #region Methods CRUD
        public CompanyInfoDto GetCompanyInfo()
        {
            var t = _companyInfoService.GetCompanyInfo();
            return t;          
        }

        [HttpPost]
        public void UpdateCompanyInfo(object companyInfo)
        {
            var companyInfoModel = JsonConvert.DeserializeObject<CompanyInfoDto>(companyInfo.ToString());            
            {
                //_companyInfoService
            }
        }

        #endregion

        #region Helper methods
        #endregion
    }
}
