namespace Kdx.Contracts.DTOs
{
    public class InterlockIO
    {
        public int PlcId { get; set; }

        public string? IOAddress { get; set; }

        public int InterlockConditionId { get; set; }

        public bool IsOnCondition { get; set; } = false;

        public int ConditionUniqueKey { get; set; }

    }
}
