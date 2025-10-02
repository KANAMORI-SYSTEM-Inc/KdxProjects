namespace Kdx.Contracts.DTOs
{
    public class IO
    {
        public string Address { get; set; } = string.Empty;

        public int PlcId { get; set; }

        // Properties from KdxDesigner version
        public string? IOText { get; set; }

        public string? XComment { get; set; }

        public string? YComment { get; set; }

        public string? FComment { get; set; }

        public string? IOName { get; set; }

        public string? IOExplanation { get; set; }

        public string? IOSpot { get; set; }

        public string? UnitName { get; set; }

        public string? System { get; set; }

        public string? StationNumber { get; set; }

        public string? IONameNaked { get; set; }

        public string? LinkDevice { get; set; }

        // Properties from KdxMigrationAPI version
        public string? Name { get; set; }

        public int IOType { get; set; }

        public bool IsInverted { get; set; }

        public bool IsEnabled { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}