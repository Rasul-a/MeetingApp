using Applicaion.Dto;
using Domain.Meetings;

namespace Applicaion.Extensions
{
    public static class Mapper
    {
        public static MeetingDto ToDto(this Meeting meeting)
        {
            return new MeetingDto
            {
                Id = meeting.Id,
                Name = meeting.Name,
                BeginDate = meeting.BeginDate,
                EndDate = meeting.EndDate,
                NotificationDate = meeting.NotificationDate,
            };
        }

    }
}
