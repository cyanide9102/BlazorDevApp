using Ardalis.Specification;

namespace BlazorDevApp.Core.Interfaces;
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
    IQueryable<T> Get();
}
