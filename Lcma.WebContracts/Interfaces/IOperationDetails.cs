namespace Lcma.WebContracts.Interfaces
{
    public interface IOperationDetails
    {
        bool Succeeded { get; }
        string Message { get; }
        string Property { get; }
    }
}
