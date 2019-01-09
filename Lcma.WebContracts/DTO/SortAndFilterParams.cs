namespace Lcma.WebContracts.DTO
{
    public class SortAndFilterParams
    {
        public string SortProperty { get; set; }
        public string DateStartFromFilter { get; set; }
        public string dateStartToFilter { get; set; }
        public string PriorityFilter { get; set; }
        public string ManagerFilter { get; set; }
    }
}
