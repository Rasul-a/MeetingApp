using Domain.Meetings;
using System;

namespace Applicaion.Services.UpdateBeginDate
{
    public class UpdateBeginDateService : IUpdateBeginDateService
    {
        private readonly IMeetingRepository repository;

        public UpdateBeginDateService(IMeetingRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(int id, DateTime date)
        {
            var meet = repository.GetById(id);
            if (date <= DateTime.Now)
                throw new ArgumentException("Встреча может планироваться только на будующее время");
            if (meet == null)
                throw new System.Exception("Запись не найдена");
            meet.UpdateBeginDate(date,repository);
        }
    }
}
