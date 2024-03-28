using CoverGo.Task.Domain.Company.Entities;

namespace CoverGo.Task.Application;

public interface ICompaniesQuery
{
    public ValueTask<List<Company>> ExecuteAsync();
}
