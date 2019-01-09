using Lcma.WebContracts.DTO;
using System;
using System.Collections.Generic;

namespace Lcma.WebContracts.Interfaces
{
    public interface IService<T> : IDisposable where T : DTOBase
    {
        T GetById(Guid? id);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(Guid? id);
    }
}
