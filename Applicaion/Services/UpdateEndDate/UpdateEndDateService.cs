using Domain.Meetings;
using System;

namespace Applicaion.Services.UpdateEndDate
{
    public class UpdateEndDateService : IUpdateEndDateService
    {
        private readonly IMeetingRepository repository;

        public UpdateEndDateService(IMeetingRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(int id, DateTime date)
        {
            var meet = repository.GetById(id);
            if (meet == null)
                throw new System.Exception("Запись не найдена");
            meet.UpdateEndDate(date,repository);
        }
    }
}
