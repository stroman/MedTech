using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MedTech.Application.Services.TextResources;
using MedTech.Application.DTO.TextResources;
using Newtonsoft.Json;
using MedTech.Core.Helpers;
using MedTech.Web.Models;

namespace MedTech.Web.Controllers
{
    public class TextResourceController : ApiController
    {
        #region Fields

        private readonly ITextResourceService _textResourceService;

        #endregion

        #region Ctor
        public TextResourceController(ITextResourceService textResourceService)
        {
            _textResourceService = textResourceService;
        }
        #endregion

        #region Methods CRUD
        [HttpPut]
        public ResponseModel GetTextResources(object filter)
        {
            var filterModel = JsonConvert.DeserializeObject<RequestFilter>(filter.ToString());
            int totalCount;
            int filteredCount;
            var tResources = _textResourceService.GetAllTextResource(filterModel, out totalCount);
            var responseModel = new ResponseModel {
                TotalCount = totalCount,
                FilteredCount =15,
                Rows = tResources
            };
            return responseModel;           
        }
        #endregion

        #region Helper methods
        #endregion
    }
}
