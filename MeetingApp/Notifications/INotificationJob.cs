using Domain.Meetings;
using System.Threading.Tasks;

namespace MeetingApp.Notifications
{
    public interface INotificationJob
    {
        /// <summary>
        /// Метод, который будет выполнятся при наступлении времени уведомления
        /// </summary>
        /// <param name="meeting">Данный о встречи</param>
        /// <returns></returns>
        Task Execute(Meeting meeting);
    }
}
