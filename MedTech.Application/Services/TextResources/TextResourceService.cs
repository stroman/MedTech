﻿using System;
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
            tResources = SortTextResources(SearchTextResources(tResources, filter), filter);            
            totalCount = tResources.Count();
            return tResources.Skip((filter.Page - 1) * filter.Count).Take(filter.Count).Select(tr => tr.ToDto()).ToList();                
        }

        public void UpdateTextResource(TextResourceDto model)
        {
            if (model == null)
                throw new ArgumentNullException("text resource");
            var resource =_textResourceRepository.GetById(model.Id);
            if(resource == null)
                throw new ArgumentNullException("text resource entity");
            resource = model.ToEntity(resource);            
            _textResourceRepository.Update(resource);
        }

        public void CreateTextResource(TextResourceDto model)
        {
            if(model == null)
                throw new ArgumentNullException("text resource");
            var resource = model.ToEntity();
            _textResourceRepository.Insert(resource);
        }

        public void DeleteTextResource(long id)
        {
            var resource = _textResourceRepository.GetById(id);
            if (resource == null)
                throw new ArgumentNullException("text resource entity");
            _textResourceRepository.Delete(resource);
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
        private static IEnumerable<TextResource> SortTextResources(IEnumerable<TextResource> textResources, RequestFilter filter)
        {
            var field = filter.Sorting.First().Key;
            var type = filter.Sorting.First().Value;
            Func<TextResource, string> orderingFunction = (c => field == "key"  ? c.Key  
                                                              : field == "value" ? c.Value  : "");
            return type == "asc" ? textResources.OrderBy(orderingFunction) : textResources.OrderByDescending(orderingFunction);
        }
        private static IEnumerable<TextResource> SearchTextResources(IEnumerable<TextResource> textResources, RequestFilter filter)
        {
            foreach(var item in filter.Filter)
            {
                if(item.Key == "key")
                {
                    textResources = textResources.Where(k => k.Key.ToLower().Contains(item.Value.ToLower()));
                }
                if(item.Key == "value")
                {
                    textResources = textResources.Where(v => v.Value.ToLower().Contains(item.Value.ToLower()));
                }
            }

            return textResources;            
        }
        #endregion
    }
}
