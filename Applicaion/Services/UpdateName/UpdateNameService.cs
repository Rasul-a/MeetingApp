using Domain.Meetings;

namespace Applicaion.Services.UpdateName
{
    public class UpdateNameService : IUpdateNameService
    {
        private readonly IMeetingRepository repository;

        public UpdateNameService(IMeetingRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(int id, string name)
        {
            var meet = repository.GetById(id);
            if (meet == null)
                throw new System.Exception("Запись не найдена");
            meet.UpdateName(name);
        }
    }
}
