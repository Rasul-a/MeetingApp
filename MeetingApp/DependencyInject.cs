using Applicaion.Services.GetAll;
using Applicaion.Services.Create;
using Applicaion.Services.Delete;
using Applicaion.Services.UpdateBeginDate;
using Applicaion.Services.UpdateEndDate;
using Applicaion.Services.UpdateNotificationDate;
using Applicaion.Services.ExportList;
using Domain.Meetings;
using Infrastructure.DateAccess;
using Microsoft.Extensions.DependencyInjection;
using Applicaion.Services.UpdateName;
using Applicaion.AppServices;
using Infrastructure.AppServices;

namespace MeetingApp
{
    public static class DependencyInject
    {
        public static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IMeetingRepository, MeetingRepository>()
                .AddScoped<IGetAllService, GetAllService>()
                .AddScoped<ICreateService, CreateService>()
                .AddScoped<IDeleteService, DeleteService>()
                .AddScoped<IUpdateNameService, UpdateNameService>()
                .AddScoped<IUpdateBeginDateService, UpdateBeginDateService>()
                .AddScoped<IUpdateEndDateService, UpdateEndDateService>()
                .AddScoped<IUpdateNotificationDateService, UpdateNotificationDateService>()
                .AddScoped<IFileFactory, FileFactory>()
                .AddScoped<IExportListService, ExportListService>()
                .BuildServiceProvider();
        }
    }
}
