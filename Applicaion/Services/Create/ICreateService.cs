using Applicaion.Dto;

namespace Applicaion.Services.Create
{
    public interface ICreateService
    {
        int Execute(MeetingDto model);
    }
}
