using Domain.Meetings;
using System;

namespace Applicaion.Services.UpdateNotificationDate
{
    public class UpdateNotificationDateService : IUpdateNotificationDateService
    {
        private readonly IMeetingRepository repository;

        public UpdateNotificationDateService(IMeetingRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(int id, DateTime date)
        {
            var meet = repository.GetById(id);
            if (meet == null)
                throw new System.Exception("Запись не найдена");
            meet.UpdateNotificationDate(date);
        }
    }
}
