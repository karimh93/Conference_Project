using Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ISponsorRepository
    {
        IEnumerable<Sponsors> GetAllSponsors();
        Sponsors GetSponsorById(int id);
        Sponsors Update(Sponsors sponsorToUpdate);
        Sponsors AddSponsor(Sponsors sponsorToBeAdded);
        bool IsUniqueSponsor(string sponsorName);
        void Delete(Sponsors sponsorToDelete);
        void Save();
    }
    public class SponsorRepository : ISponsorRepository
    {
        private readonly ConferenceContext conferenceContext;
        public SponsorRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }
        public IEnumerable<Sponsors> GetAllSponsors()
        {
            return conferenceContext.Sponsors.Include(x => x.SponsorType).ToList();
        }
        public Sponsors AddSponsor(Sponsors sponsorToBeAdded)
        {
            var addedSponsor = conferenceContext.Add(sponsorToBeAdded);
            conferenceContext.SaveChanges();
            return addedSponsor.Entity;
        }


        public Sponsors GetSponsorById(int id)
        {
            return conferenceContext.Sponsors.Find(id);
        }


        public Sponsors Update(Sponsors sponsorToUpdate)
        {
            var updatedSponsor = conferenceContext.Update(sponsorToUpdate);
            conferenceContext.SaveChanges();
            return updatedSponsor.Entity;
        }
        public bool IsUniqueSponsor(string sponsorName)
        {
            int nr = conferenceContext.Sponsors.Count(x => x.Name == sponsorName);
            if (nr == 0)
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
            sponsorToDelete = conferenceContext.Sponsors.Find(sponsorToDelete.Id);
            conferenceContext.Sponsors.Remove(sponsorToDelete);

        }
        public void Save()
        {
            conferenceContext.SaveChanges();
        }
    }
}
