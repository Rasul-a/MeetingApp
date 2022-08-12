using Domain.Meetings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingApp.Notifications
{
    /// <summary>
    /// Сервис уведомления
    /// </summary>
    public class NotificationService
    {
        private Timer _timer;
        private Meeting meet;
        private ServiceProvider sp;
        private readonly INotificationJob notificationJob;

        public NotificationService(ServiceProvider sp, INotificationJob notificationJob)
        {
            this.sp = sp;
            this.notificationJob = notificationJob;
            meet = null;
        }
        /// <summary>
        /// Запуск сервиса
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            _timer = new Timer(async _ => await OnTimerFiredAsync(), null, 0, Timeout.Infinite);
        }
        /// <summary>
        /// Обновления времени следующего уведомления
        /// </summary>
        /// <returns></returns>
        public async Task UpdateNotice()
        {
            var repository = sp.GetService<IMeetingRepository>();
            //получаем самое ближайшее событие
            meet = repository.GetAll()
                .Where(a => a.NotificationDate > DateTime.Now)
                .ToList()
                .OrderBy(a => a.NotificationDate)
                .FirstOrDefault();
            var d = new TimeSpan(1, 0, 0, 0);
            if (meet != null)
                //вычисляем количество времени для таймера
                d = meet.NotificationDate - DateTime.Now;
            //если время слишком большое, то ставим время в один день
            if (d.Days > 1)
            {
                d = new TimeSpan(1, 0, 0, 0);
                //обнуляем переменную, чтобы при следующем запуске не выводилось уведомление
                meet = null;
            }
            _timer.Change(d, Timeout.InfiniteTimeSpan);
        }

        private async Task OnTimerFiredAsync()
        {
            if (meet != null)
            {
                notificationJob.Execute(meet);
            }
            UpdateNotice();
        }
    }
}
