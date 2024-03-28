using CoverGo.Task.Domain.Company.Entities;

namespace CoverGo.Task.Application;

public interface ICompaniesWriteRepository
{
    public ValueTask<Company> GetById(string id, CancellationToken cancellationToken = default);
}
