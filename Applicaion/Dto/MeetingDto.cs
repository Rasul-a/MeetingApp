using System;

namespace Applicaion.Dto
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
