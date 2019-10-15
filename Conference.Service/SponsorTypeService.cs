using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Service
{
    public interface ISponsorTypeService
    {
        SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded);
        void Delete(SponsorTypes sponsorTypeToDelete);
        IEnumerable<SponsorTypes> GetAllSponsorTypes();
        SponsorTypes GetSponsorTypeById(int id);
        void Save();
        SponsorTypes UpdateSponsorType(SponsorTypes sponsorTypeToUpdate);
    }

    public class SponsorTypeService : ISponsorTypeService
    {
        private readonly ISponsorTypeRepository sponsorTypeRepository;
        public SponsorTypeService(ISponsorTypeRepository sponsorTypeRepository)
        {
            this.sponsorTypeRepository = sponsorTypeRepository;
        }
        public SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded)
        {
            if (IsUniqueSponsorTypeName(sponsorTypeToBeAdded.Name))
            {
                return sponsorTypeRepository.AddSponsorType(sponsorTypeToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<SponsorTypes> GetAllSponsorTypes()
        {
            return sponsorTypeRepository.GetAllSponsorTypes();
        }

        public SponsorTypes GetSponsorTypeById(int id)
        {
            return sponsorTypeRepository.GetSponsorTypeById(id);
        }

        public SponsorTypes UpdateSponsorType(SponsorTypes sponsorTypeToUpdate)
        {
            return sponsorTypeRepository.Update(sponsorTypeToUpdate);
        }
        private bool IsUniqueSponsorTypeName(string sponsorTypeName)
        {
            if (sponsorTypeRepository.IsUniqueSponsorType(sponsorTypeName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(SponsorTypes sponsorTypeToDelete)
        {
            sponsorTypeRepository.Delete(sponsorTypeToDelete);

        }
        public void Save()
        {
            sponsorTypeRepository.Save();
        }
    }
}
