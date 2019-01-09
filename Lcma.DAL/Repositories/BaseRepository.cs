using Lcma.DAL.Context;
using Lcma.Domain.Entities;
using Lcma.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lcma.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly MyAppContext _db;

        public BaseRepository(MyAppContext db) => _db = db;

        public void Add(T entity) => _db.Set<T>().Add(entity);

        public T GetById(Guid id) => _db.Set<T>().Find(id);

        public IEnumerable<T> List() => _db.Set<T>().AsEnumerable();

        public IEnumerable<T> List(Func<T, bool> predicate) => _db.Set<T>().Where(predicate).AsEnumerable();

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes.Aggregate(_db.Set<T>().AsQueryable(), (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings.Aggregate(queryableResultWithIncludes, (current, include) => current.Include(include));

            return secondaryResult.Where(spec.Criteria).AsEnumerable();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }
    }
}
