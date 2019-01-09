using System;

namespace Lcma.WebContracts.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid id) : base($"Item with id '{id}' was not found.") { }
    }
}
