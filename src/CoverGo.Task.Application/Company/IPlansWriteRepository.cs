using CoverGo.Task.Domain.Company.Entities;

namespace CoverGo.Task.Application;

public interface IPlansWriteRepository
{
    public ValueTask<Plan> GetById(string id, CancellationToken cancellationToken = default);
}
