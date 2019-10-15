using Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ITalksRepository
    {
        IEnumerable<Talks> GetAllTalks();
        Talks GetTalkById(int id);
        Talks Update(Talks talkToUpdate);
        Talks AddTalk(Talks talkToBeAdded);
        bool IsUniqueTalk(string talkName);
        void Delete(Talks talkToDelete);
        void Save();
    }
    public class TalksRepository : ITalksRepository
    {
        private readonly ConferenceContext conferenceContext;
        public TalksRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }
        public IEnumerable<Talks> GetAllTalks()
        {
            return conferenceContext.Talks.Include(x => x.Speaker).ToList();
        }
        public Talks AddTalk(Talks talkToBeAdded)
        {
            var addedTalk = conferenceContext.Add(talkToBeAdded);
            conferenceContext.SaveChanges();
            return addedTalk.Entity;
        }


        public Talks GetTalkById(int id)
        {
            return conferenceContext.Talks.Include(x => x.Speaker).Where(x => x.Id == id).First();
        }


        public Talks Update(Talks talkToUpdate)
        {
            var updatedTalk = conferenceContext.Update(talkToUpdate);
            conferenceContext.SaveChanges();
            return updatedTalk.Entity;
        }
        public bool IsUniqueTalk(string talkName)
        {
            int nr = conferenceContext.Talks.Count(x => x.Name == talkName);
            if (nr == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(Talks talkToDelete)
        {
            talkToDelete = conferenceContext.Talks.Find(talkToDelete.Id);
            conferenceContext.Talks.Remove(talkToDelete);

        }
        public void Save()
        {
            conferenceContext.SaveChanges();
        }
    }
}
