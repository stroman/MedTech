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
            var tResources = _textResourceService.GetAllTextResource(filterModel, out totalCount);
            var responseModel = new ResponseModel {
                TotalCount = totalCount,               
                Rows = tResources
            };
            return responseModel;           
        }        
        [HttpPost]
        public void DoTextResource(int id, object tResource)
        {
            var tResourceModel = JsonConvert.DeserializeObject<TextResourceDto>(tResource.ToString());
            if (id == 0 && tResourceModel.Id == 0)
            {
                _textResourceService.CreateTextResource(tResourceModel);
            }
            else
            {
                _textResourceService.UpdateTextResource(tResourceModel);
            }
        }
        [HttpDelete]
        public void DeleteTextResource(long id)
        {
            _textResourceService.DeleteTextResource(id);
        }


        #endregion

        #region Helper methods
        #endregion
    }
}
