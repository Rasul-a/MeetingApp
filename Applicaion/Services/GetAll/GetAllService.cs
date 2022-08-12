using Applicaion.Dto;
using Applicaion.Extensions;
using Domain.Meetings;
using System.Collections.Generic;
using System.Linq;

namespace Applicaion.Services.GetAll
{
    public class GetAllService: IGetAllService
    {
        private readonly IMeetingRepository repository;

        public GetAllService(IMeetingRepository repository)
        {
            this.repository = repository;
        }
        public List<MeetingDto> Execute()
        {
            return repository.GetAll().Select(a => a.ToDto()).ToList();
        }
    }
}
