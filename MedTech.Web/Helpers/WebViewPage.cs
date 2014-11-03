using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedTech.Application.Services.TextResources;
using System.Web.Mvc;

namespace MedTech.Web.Helpers
{
    public delegate string ResourceGetter(string resourceKey);
    public abstract class WebViewPage<TModel> :  System.Web.Mvc.WebViewPage<TModel>
    {
        private ITextResourceService _textResourceService;

        public ResourceGetter T
        {
            get
            {
                return _textResourceService.GetResourceValue;
            }
        }

        public override void InitHelpers()
        {
            base.InitHelpers();
            _textResourceService = DependencyResolver.Current.GetService<ITextResourceService>();
        }
    }
}