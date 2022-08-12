using Domain.Meetings;
using System;
using System.Threading.Tasks;

namespace MeetingApp.Notifications
{
    public class NotificationJob : INotificationJob
    {
        public async Task Execute(Meeting meeting)
        {
            await Console.Out.WriteLineAsync($"!!!!!!!!!{meeting.Name} с {meeting.BeginDate} по {meeting.EndDate} уведомление в {meeting.NotificationDate}");
        }
    }
}
