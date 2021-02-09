using System.Threading;
using System.Threading.Tasks;

namespace Moodle.Core.Interfaces.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}