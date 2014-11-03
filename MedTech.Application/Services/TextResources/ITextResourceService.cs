using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MedTech.Application.DTO.TextResources;
using MedTech.Core.Helpers;

namespace MedTech.Application.Services.TextResources
{
    public interface ITextResourceService
    {
        List<TextResourceDto> GetAllTextResource(RequestFilter filter, out int totalCount);
        string GetResourceValue(string resourceKey);
    }
}
