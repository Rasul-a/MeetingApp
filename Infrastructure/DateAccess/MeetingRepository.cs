using Domain.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DateAccess
{
    public class MeetingRepository : IMeetingRepository
    {
        private static int id = 1;
        private List<Meeting> meetings=new();
        public MeetingRepository()
        {
            meetings = new List<Meeting>()
            {
                new Meeting(GetNextId(),"Meet1",new DateTime(2022,11,10,11,0,0),new DateTime(2022,11,10,12,0,0),new DateTime(2022,11,10,10,0,0),this),
                new Meeting(GetNextId(),"Meet2",new DateTime(2022,08,12,11,0,0),new DateTime(2022,08,12,12,0,0),new DateTime(2022,08,12,2,27,35),this)
            };
        }

        public int GetNextId()
        {
            return id++;
        }

        public void Add(Meeting meeting)
        {
            meetings.Add(meeting);
        }

        public void Delete(Meeting meeting)
        {
            meetings.Remove(meeting);
        }

        public IList<Meeting> GetAll()
        {
            return meetings;
        }

        public Meeting GetById(int id)
        {
            return meetings.FirstOrDefault(a => a.Id == id);
        }

        public IList<Meeting> GetByDay(DateTime date)
        {
            return meetings.Where(a => a.BeginDate.Date == date.Date).ToList();
        }
    }
}
