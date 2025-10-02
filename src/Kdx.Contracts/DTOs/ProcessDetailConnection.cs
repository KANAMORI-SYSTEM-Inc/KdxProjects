namespace Kdx.Contracts.DTOs
{
    public class ProcessDetailConnection
    {
        public int Id { get; set; }

        // Note: CycleId doesn't exist in the database table
        // Use ProcessDetail.CycleId to filter connections by cycle
        public int FromProcessDetailId { get; set; }

        public int? ToProcessDetailId { get; set; }

        public int? ToProcessId { get; set; }
    }
}