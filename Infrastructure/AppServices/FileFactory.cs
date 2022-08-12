using Applicaion.AppServices;
using Domain.Meetings;
using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.AppServices
{
    public class FileFactory : IFileFactory
    {
        public string CreateExportList(List<Meeting> meetings)
        {
            var fileName = $"ExportList {DateTime.Now.ToString("yyyy.MM.dd hhmss")}.txt";
            var cd = new DirectoryInfo(Environment.CurrentDirectory);
            cd.CreateSubdirectory("files");
            var filePath = Path.Combine(Environment.CurrentDirectory, "files", fileName);
            using var file = new StreamWriter(filePath, false);
            foreach (var item in meetings)
            {
                file.WriteLine($"{item.Name} с {item.BeginDate} по {item.EndDate} уведомление в {item.NotificationDate}");
            }
            return filePath;
        }
    }
}
