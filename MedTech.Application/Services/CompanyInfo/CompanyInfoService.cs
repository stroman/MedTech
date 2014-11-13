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
        private readonly IRepository<Contact> _contactRepository;
        #endregion

        #region Ctor
        public CompanyInfoService(IRepository<MedTech.Core.Domain.CompanyInfo.CompanyInfo> companyInfoRepository, IRepository<Contact> contactRepository)
        {
            _companyInfoRepository = companyInfoRepository;
            _contactRepository = contactRepository;
        }
        #endregion

        #region Methods
        public CompanyInfoDto GetCompanyInfo()
        {            
            return GetActualCompanyInfo().ToDto();
        }
        public void UpdateCompanyInfo(CompanyInfoDto companyInfo)
        {
            if (companyInfo == null)
                throw new ArgumentNullException("companyInfo");
            var entity = _companyInfoRepository.GetById(companyInfo.Id);
            if (entity == null)
                throw new ArgumentNullException("companyInfo entity");
            companyInfo.ToEntity(entity);
            _companyInfoRepository.Update(entity);

            //update, insert or delete contacts 
            var oldContacts = GetActualContactsFromCompany(companyInfo.Id);

            List<Contact> insertContacts = new List<Contact>();
            List<Contact> deleteContacts = new List<Contact>();

            if(!companyInfo.Contacts.Any() && oldContacts.Any())
            {
                deleteContacts.AddRange(oldContacts);
            }
            if (companyInfo.Contacts.Any())
            {
                foreach (var newContact in companyInfo.Contacts)
                {
                    if (!oldContacts.Select(old => old.Id).Contains(newContact.Id))
                    {
                        insertContacts.Add(newContact.ToEntity());
                    }
                    else
                    {
                        var entityContact = oldContacts.First(old => old.Id == newContact.Id);
                        _contactRepository.Update(newContact.ToEntity(entityContact));
                    }                   
                }
                foreach(var oldContact in oldContacts)
                {
                    if(!companyInfo.Contacts.Select(c => c.Id).Contains(oldContact.Id))
                    {
                        deleteContacts.Add(oldContact);
                    }
                }
            }
            _contactRepository.Insert(insertContacts);
            _contactRepository.Delete(deleteContacts);   
            
        }
        #endregion

        #region Helper methods
        private MedTech.Core.Domain.CompanyInfo.CompanyInfo GetActualCompanyInfo()
        {
            return _companyInfoRepository.Table.First();
        }

        private IEnumerable<Contact> GetActualContactsFromCompany(long companyId)
        {            
            return _contactRepository.Table.Where(con => con.CompanyId == companyId);
        }
        #endregion
    }
}
