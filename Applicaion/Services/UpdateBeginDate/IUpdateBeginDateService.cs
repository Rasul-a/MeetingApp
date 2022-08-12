using System;

namespace Applicaion.Services.UpdateBeginDate
{
    public interface IUpdateBeginDateService
    {
        void Execute(int id, DateTime date);
    }
}
