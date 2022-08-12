using Applicaion.Dto;
using Applicaion.Services.Create;
using Applicaion.Services.Delete;
using Applicaion.Services.ExportList;
using Applicaion.Services.GetAll;
using Applicaion.Services.UpdateBeginDate;
using Applicaion.Services.UpdateEndDate;
using Applicaion.Services.UpdateName;
using Applicaion.Services.UpdateNotificationDate;
using MeetingApp.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MeetingApp
{
    public class Controller
    {
        private readonly ServiceProvider serviceProvider;
        public Controller(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void GetAll()
        {
            var service = serviceProvider.GetService<IGetAllService>();
            var res = service.Execute();
            foreach (var item in res)
            {
                Console.WriteLine($"{item.Id}  {item.Name}  {item.BeginDate}  {item.EndDate}  {item.NotificationDate}");
            }
            Console.WriteLine();
        }

        public void Create(NotificationService ns)
        {
            MeetingDto model = CreateWrite();
            //для быстрого создания
            //MeetingDto model = new();
            //model.Name = "meet3";
            //model.BeginDate = new DateTime(2022, 08, 12, 10, 0, 0);
            //model.EndDate = new DateTime(2022, 11, 10, 16, 0, 0);
            //model.NotificationDate = new DateTime(2022, 08, 12, 2, 03, 30);

            var service = serviceProvider.GetService<ICreateService>();
            var res = service.Execute(model);
            ns.UpdateNotice();
            Console.WriteLine($"Встреча добавлена. ID={res}\n");
        }

        public void ExportList()
        {
            Console.WriteLine("Введите дату:");
            var date = DateTime.Parse(Console.ReadLine());
            var service = serviceProvider.GetService<IExportListService>();
            var file = service.Execute(date);
            Console.WriteLine($"Готово. Путь к файлу:{file}\n");
        }

        public void UpdateName(int id)
        {
            Console.WriteLine("Введите наименование:");
            var name = Console.ReadLine();
            var service = serviceProvider.GetService<IUpdateNameService>();
            service.Execute(id, name);
            Console.WriteLine("Готово\n");
        }

        public void UpdateBeginDate(int id)
        {
            Console.WriteLine("Введите дату и время начала:");
            var date = DateTime.Parse(Console.ReadLine());
            var service = serviceProvider.GetService<IUpdateBeginDateService>();
            service.Execute(id, date);
            Console.WriteLine("Готово\n");
        }

        public void UpdateEndDate(int id)
        {
            Console.WriteLine("Введите дату и время окончания:");
            var date = DateTime.Parse(Console.ReadLine());
            var service = serviceProvider.GetService<IUpdateEndDateService>();
            service.Execute(id, date);
            Console.WriteLine("Готово\n");
        }

        public void UpdateNotificationDate(int id, NotificationService ns)
        {
            Console.WriteLine("Введите дату и время уведомления:");
            var date = DateTime.Parse(Console.ReadLine());
            var service = serviceProvider.GetService<IUpdateNotificationDateService>();
            service.Execute(id, date);
            ns.UpdateNotice();
            Console.WriteLine("Готово\n");
        }

        public void Delete(NotificationService ns)
        {
            Console.WriteLine("Введите Id");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new Exception("Неверный формат");
            }
            var service = serviceProvider.GetService<IDeleteService>();
            service.Execute(id);
            ns.UpdateNotice();
            Console.WriteLine("Запись удалена\n");
        }

        private MeetingDto CreateWrite()
        {
            var model = new MeetingDto();
            try
            {
                Console.WriteLine("Наименование:");
                model.Name = Console.ReadLine();
                Console.WriteLine("Дата и время начала:");
                model.BeginDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Дата и время окончания:");
                model.EndDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Дата и время уведомления:");
                model.NotificationDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new Exception("Неверный формат");
            }
            return model;
        }
    }
}
