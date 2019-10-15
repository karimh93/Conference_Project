using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ISponsorTypeRepository
    {
        SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded);
        void Delete(SponsorTypes sponsorTypeToDelete);
        IEnumerable<SponsorTypes> GetAllSponsorTypes();
        SponsorTypes GetSponsorTypeById(int id);
        bool IsUniqueSponsorType(string sponsorTypeName);
        void Save();
        SponsorTypes Update(SponsorTypes sponsorTypeToUpdate);
    }

    public class SponsorTypeRepository : ISponsorTypeRepository
    {
        private readonly ConferenceContext conferenceContext;
        public SponsorTypeRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }
        public IEnumerable<SponsorTypes> GetAllSponsorTypes()
        {
            return conferenceContext.SponsorTypes.ToList();
        }
        public SponsorTypes AddSponsorType(SponsorTypes sponsorTypeToBeAdded)
        {
            var addedSponsorType = conferenceContext.Add(sponsorTypeToBeAdded);
            conferenceContext.SaveChanges();
            return addedSponsorType.Entity;
        }


        public SponsorTypes GetSponsorTypeById(int id)
        {
            return conferenceContext.SponsorTypes.Find(id);
        }


        public SponsorTypes Update(SponsorTypes sponsorTypeToUpdate)
        {
            var updatedSponsorType = conferenceContext.Update(sponsorTypeToUpdate);
            conferenceContext.SaveChanges();
            return updatedSponsorType.Entity;
        }
        public bool IsUniqueSponsorType(string sponsorTypeName)
        {
            int nr = conferenceContext.SponsorTypes.Count(x => x.Name == sponsorTypeName);
            if (nr == 0)
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
            sponsorTypeToDelete = conferenceContext.SponsorTypes.Find(sponsorTypeToDelete.Id);
            conferenceContext.SponsorTypes.Remove(sponsorTypeToDelete);

        }
        public void Save()
        {
            conferenceContext.SaveChanges();
        }

    }
}
