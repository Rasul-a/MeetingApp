using MeetingApp.Notifications;
using System;
using System.Threading.Tasks;

namespace MeetingApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sp = DependencyInject.GetServiceProvider();

            var ns = new NotificationService(sp, new NotificationJob());
            ns.Start();

            string command = "";
            var controller = new Controller(sp);
            while (command is not "0")
            {
                StartWrite();
                command = Console.ReadLine();
                try
                {
                    switch (command)
                    {
                        case "1":
                            controller.Create(ns);
                            break;
                        case "2":
                            UpdateWrite(controller, ns);
                            break;
                        case "3":
                            controller.Delete(ns);
                            break;
                        case "4":
                            controller.GetAll();
                            break;
                        case "5":
                            controller.ExportList();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("Неверная команда");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void StartWrite()
        {
            Console.WriteLine("1.Создать");
            Console.WriteLine("2.Изменить");
            Console.WriteLine("3.Удалить");
            Console.WriteLine("4.Получить список");
            Console.WriteLine("5.Экспорт в файл");
            Console.WriteLine("0.Выход");
        }
        private static void UpdateMenuWrite()
        {
            Console.WriteLine(" Изменить:");
            Console.WriteLine("  1.Наименование");
            Console.WriteLine("  2.Дата и время начала");
            Console.WriteLine("  3.Дата и время окончания");
            Console.WriteLine("  4.Дата и время уведомления");
            Console.WriteLine("  0.Назад");
        }
        private static void UpdateWrite(Controller controller, NotificationService ns)
        {
            Console.WriteLine("  Введите ID");
            var id = int.Parse(Console.ReadLine());

            string command = "";
            while (command is not "0")
            {
                UpdateMenuWrite();
                command = Console.ReadLine();
                try
                {
                    switch (command)
                    {
                        case "1":
                            controller.UpdateName(id);
                            break;
                        case "2":
                            controller.UpdateBeginDate(id);
                            break;
                        case "3":
                            controller.UpdateEndDate(id);
                            break;
                        case "4":
                            controller.UpdateNotificationDate(id, ns);
                            break;
                        case "5":
                            break;
                        default:
                            Console.WriteLine("Неверная команда");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

    }
}
