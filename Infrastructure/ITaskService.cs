using Entity;

namespace Infrastructure
{
    public interface ITaskService
    {
        Task<int> TakeBackup();
        Task<Detaisforbackup> Detailsforbackup();
    }
}
