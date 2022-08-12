using Domain.Meetings;

namespace Applicaion.Services.Delete
{
    public class DeleteService : IDeleteService
    {
        private readonly IMeetingRepository repository;

        public DeleteService(IMeetingRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(int id)
        {
            var meet = repository.GetById(id);
            if (meet == null)
                throw new System.Exception("Запись не найдена");
            repository.Delete(meet);
        }
    }
}
