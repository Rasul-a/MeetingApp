using Applicaion.AppServices;
using Domain.Meetings;
using System;
using System.Linq;

namespace Applicaion.Services.ExportList
{
    public class ExportListService : IExportListService
    {
        private readonly IMeetingRepository repository;
        private readonly IFileFactory fileFactory;

        public ExportListService(IMeetingRepository repository, IFileFactory fileFactory)
        {
            this.repository = repository;
            this.fileFactory = fileFactory;
        }
        public string Execute(DateTime date)
        {
            var list = repository.GetByDay(date).ToList();
            if (list.Count == 0)
                throw new Exception("Встречи на данный день не найдены");
            var fileName = fileFactory.CreateExportList(list);
            return fileName;
        }
    }
}
