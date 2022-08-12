using System;
using System.Linq;

namespace Domain.Meetings
{
    public class Meeting
    {
        public int Id { get; private set;}
        public string Name { get; private set;}
        public DateTime BeginDate { get; private set;}
        public DateTime EndDate { get; private set;}
        public DateTime NotificationDate { get; private set;}

        public Meeting(int id,
                       string name,
                       DateTime beginDate,
                       DateTime endDate,
                       DateTime notificationDate,
                       IMeetingRepository repository)
        {
            NameRule(name);
            BeginEndDateRule(beginDate, endDate);
            NotificationDateRule(beginDate, notificationDate);
            IntersectionRule(beginDate,endDate,repository);

            Id = id;
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;
            NotificationDate = notificationDate;
        }

        public void UpdateName(string name)
        {
            NameRule(name);
            Name = name;
        }

        public void UpdateBeginDate(DateTime beginDate, IMeetingRepository repository)
        {
            BeginEndDateRule(beginDate, EndDate);
            NotificationDateRule(beginDate, NotificationDate);
            IntersectionRule(beginDate, EndDate, repository);

            BeginDate = beginDate;
        }

        public void UpdateEndDate(DateTime endDate, IMeetingRepository repository)
        {
            BeginEndDateRule(BeginDate, endDate);
            IntersectionRule(BeginDate, endDate, repository);

            EndDate = endDate;
        }

        public void UpdateNotificationDate(DateTime notificationDate)
        {
            NotificationDateRule(BeginDate, notificationDate);
            NotificationDate = notificationDate;
        }

        private void BeginEndDateRule(DateTime beginDate, DateTime endDate)
        {
            if (beginDate >= endDate)
                throw new ArgumentException("Дата начала должна быть меньше даты конца");
        }

        private void NameRule(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Наименование не должно быть пустым");
        }

        private void NotificationDateRule(DateTime beginDate, DateTime notificationDate)
        {
            if (beginDate <= notificationDate)
                throw new ArgumentException("Дата уведомления должна быть меньше даты начала");
        }

        private void IntersectionRule(DateTime beginDate, DateTime endDate, IMeetingRepository repository)
        {
            var meet = repository.GetAll()
                .Where(a=>a.Id!=Id)
                .FirstOrDefault(a=>(a.BeginDate<=beginDate && beginDate <= a.EndDate)
            || (a.BeginDate <= endDate && endDate <= a.EndDate));
            if (meet!=null)
            {
                throw new ArgumentException($"Пересечение co встречей {meet.Id}-{meet.Name}, выберите другое время");
            }
        }
    }
}
