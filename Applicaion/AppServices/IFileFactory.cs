using Domain.Meetings;
using System.Collections.Generic;

namespace Applicaion.AppServices
{
    public interface IFileFactory
    {
        string CreateExportList(List<Meeting> meetings);
    }
}
