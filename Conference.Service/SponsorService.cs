using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Service
{
    public interface ISponsorService
    {
        IEnumerable<Sponsors> GetAllSponsors();
        Sponsors GetSponsorById(int id);
        Sponsors AddSponsor(Sponsors sponsorToBeAdded);
        Sponsors UpdateSponsor(Sponsors sponsorToUpdate);
        void Delete(Sponsors sponsorToDelete);
        void Save();
    }
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository sponsorRepository;
        public SponsorService(ISponsorRepository sponsorRepository)
        {
            this.sponsorRepository = sponsorRepository;
        }
        public Sponsors AddSponsor(Sponsors sponsorToBeAdded)
        {
            if (IsUniqueSponsor(sponsorToBeAdded.Name))
            {
                return sponsorRepository.AddSponsor(sponsorToBeAdded);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Sponsors> GetAllSponsors()
        {
            return sponsorRepository.GetAllSponsors();
        }

        public Sponsors GetSponsorById(int id)
        {
            return sponsorRepository.GetSponsorById(id);
        }

        public Sponsors UpdateSponsor(Sponsors sponsorToUpdate)
        {
            return sponsorRepository.Update(sponsorToUpdate);
        }
        private bool IsUniqueSponsor(string sponsorName)
        {
            if (sponsorRepository.IsUniqueSponsor(sponsorName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(Sponsors sponsorToDelete)
        {
            sponsorRepository.Delete(sponsorToDelete);

        }
        public void Save()
        {
            sponsorRepository.Save();
        }
    }
}
