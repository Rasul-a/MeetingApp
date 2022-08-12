using System;

namespace Applicaion.Services.UpdateNotificationDate
{
    public interface IUpdateNotificationDateService
    {
        void Execute(int id, DateTime date);
    }
}
