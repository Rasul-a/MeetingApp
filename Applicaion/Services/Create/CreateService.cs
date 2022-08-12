using Applicaion.Dto;
using Domain.Meetings;
using System;

namespace Applicaion.Services.Create
{
    public class CreateService: ICreateService
    {
        private readonly IMeetingRepository repository;

        public CreateService(IMeetingRepository repository)
        {
            this.repository = repository;
        }

        public int Execute(MeetingDto model)
        {
            var id = repository.GetNextId();
            if (model.BeginDate <= DateTime.Now)
                throw new ArgumentException("Встреча может планироваться только на будующее время");
            var meet = new Meeting(id,
                model.Name,
                model.BeginDate,
                model.EndDate,
                model.NotificationDate,
                repository);
            repository.Add(meet);
            return id;
        }
    }
}
