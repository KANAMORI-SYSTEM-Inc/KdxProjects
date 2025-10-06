namespace Kdx.Contracts.DTOs
{
    public class IO
    {
        public string Address { get; set; } = string.Empty; // アドレス

        public int PlcId { get; set; }

        // Properties from KdxDesigner version
        public string? IOText { get; set; }

        public string? XComment { get; set; } // X_Comment

        public string? YComment { get; set; } // Y_Comment

        public string? FComment { get; set; } // F_Comment

        public string? IOName { get; set; } // アクチュエータ名称

        public string? IOExplanation { get; set; } // アクチュエータ説明

        public string? IOSpot { get; set; } // ユニット設置場所

        public string? UnitName { get; set; } // ユニット名称

        public string? System { get; set; } // 系統

        public string? StationNumber { get; set; } // 局番

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