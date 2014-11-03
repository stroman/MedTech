using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MedTech.Core.Data;
using MedTech.Core.Domain.TextResources;
using MedTech.Application.DTO.TextResources;
using MedTech.Application.Mapping;
using MedTech.Core.Helpers;

namespace MedTech.Application.Services.TextResources
{
    /// <summary>
    /// Texts resource service
    /// </summary>
    public class TextResourceService : ITextResourceService
    {
        #region Fields

        private readonly IRepository<TextResource> _textResourceRepository;
        #endregion

        #region Ctor
        public TextResourceService(IRepository<TextResource> textResourceRepository)
        {
            _textResourceRepository = textResourceRepository;
        }
        #endregion

        #region Methods
        public List<TextResourceDto> GetAllTextResource(RequestFilter filter, out int totalCount)
        {
            var tResources = GetActualTextResource();
            var list = tResources as IList<TextResource> ?? tResources.ToList();
            totalCount = list.Count();
            //tResources = SortTextResources(SearchTextResources(enumerable, filter), filter);
            //enumerable = tResources as IList<TextResource> ?? tResources.ToList();

            return list.Skip((filter.Page - 1) * filter.Count).Take(filter.Count).Select(tr => tr.ToDto()).ToList();                
        }

        public string GetResourceValue(string resourceKey)
        {
            var resource = GetActualTextResource().FirstOrDefault(tr => tr.Key == resourceKey);
            if( resource ==  null)
            {
                //throw new ArgumentNullException("Resource");
                return resourceKey;
            }
            return resource.Value;
        }
        #endregion

        #region Helper methods
        private IEnumerable<TextResource> GetActualTextResource()
        {
            return _textResourceRepository.Table;
        }
        #endregion
    }
}
