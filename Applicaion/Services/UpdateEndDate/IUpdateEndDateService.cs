using System;

namespace Applicaion.Services.UpdateEndDate
{
    public interface IUpdateEndDateService
    {
        void Execute(int id, DateTime date);
    }
}
