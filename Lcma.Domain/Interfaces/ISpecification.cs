using Lcma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lcma.Domain.Interfaces
{
    public interface ISpecification<T> where T : EntityBase
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
