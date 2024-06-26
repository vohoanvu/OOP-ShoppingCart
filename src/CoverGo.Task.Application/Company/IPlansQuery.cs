using CoverGo.Task.Domain.Company.Entities;

namespace CoverGo.Task.Application;

public interface IPlansQuery
{
    public ValueTask<List<Plan>> ExecuteAsync();
}
