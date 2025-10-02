namespace Kdx.Contracts.DTOs
{
    public class MnemonicDevice
    {
        public long? ID { get; set; }

        public int MnemonicId { get; set; } // Process: 1, ProcessDetail:2, Operation:3

        public int RecordId { get; set; }  // NemonicIdに対応するテーブルのレコードID

        public string DeviceLabel { get; set; } = "L"; // L (Mの場合もある）

        public int StartNum { get; set; } // 1000

        public int OutCoilCount { get; set; } // 10

        public int PlcId { get; set; }

        public string? Comment1 { get; set; }

        public string? Comment2 { get; set; }

        // L1000 ~ L1009がレコードに対するアウトコイルになる。
    }
}