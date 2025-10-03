namespace Kdx.Contracts.DTOs
{
    public class Interlock
    {
        public int Id { get; set; }

        public int PlcId { get; set; }

        public int CylinderId { get; set; }

        public int SortId { get; set; }

        public int ConditionCylinderId { get; set; }

        public int? PreConditionID1 { get; set; }

        public int? PreConditionID2 { get; set; }

        public int GoOrBack { get; set; } = 0;
    }
}
