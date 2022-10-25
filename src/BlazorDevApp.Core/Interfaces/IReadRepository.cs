using Ardalis.Specification;

namespace BlazorDevApp.Core.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    IQueryable<T> Get();
}
