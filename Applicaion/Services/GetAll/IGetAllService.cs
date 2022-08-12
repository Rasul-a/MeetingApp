using Applicaion.Dto;
using System.Collections.Generic;

namespace Applicaion.Services.GetAll
{
    public interface IGetAllService
    {
        List<MeetingDto> Execute();
    }
}
