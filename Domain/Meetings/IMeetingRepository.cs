using System;
using System.Collections.Generic;

namespace Domain.Meetings
{
    public interface IMeetingRepository
    {
        void Add(Meeting meeting);
        void Delete(Meeting meeting);
        Meeting GetById(int id);
        IList<Meeting> GetAll();
        IList<Meeting> GetByDay(DateTime date);
        int GetNextId();
    }
}
