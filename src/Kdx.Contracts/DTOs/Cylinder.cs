namespace Kdx.Contracts.DTOs
{
    public class Cylinder
    {
        public int Id { get; set; }
        public int PlcId { get; set; } = 0;  // デフォルト値を0に設定
        public string? PUCO { get; set; }
        public string CYNum { get; set; } = string.Empty;
        public string? Go { get; set; }
        public string? Back { get; set; }
        public string? OilNum { get; set; }
        public int? MachineNameId { get; set; }
        public int? DriveSubId { get; set; }
        public int? PlaceId { get; set; }
        public int? CYNameSub { get; set; }
        public int? SensorId { get; set; }
        public string? FlowType { get; set; }
        public int? GoSensorCount { get; set; }
        public int? BackSensorCount { get; set; }
        public string? RetentionSensorGo { get; set; }
        public string? RetentionSensorBack { get; set; }
        public int? SortNumber { get; set; }
        public int? FlowCount { get; set; }
        public string? FlowCYGo { get; set; } = string.Empty;
        public string? FlowCYBack { get; set; } = string.Empty;
    }
}
