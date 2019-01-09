using Lcma.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Lcma.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> List();
        IEnumerable<T> List(Func<T, bool> predicate);
        IEnumerable<T> List(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
