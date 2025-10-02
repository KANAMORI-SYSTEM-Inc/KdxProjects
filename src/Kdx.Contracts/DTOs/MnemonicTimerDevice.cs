namespace Kdx.Contracts.DTOs
{
    public class MnemonicTimerDevice
    {
        public int MnemonicId { get; set; }             // Process: 1, ProcessDetail:2, Operation:3, CY:4

        public int RecordId { get; set; }               // MnemonicIdに対応するテーブルのレコードID

        public int TimerId { get; set; }                // TimerテーブルのID（NULLを許可しない）
        public int? TimerCategoryId { get; set; }       // RecordIdに対応する処理番号
        public string TimerDeviceT { get; set; } = "T0";  // RecordIdに対応する処理番号のデバイス
        public string TimerDeviceZR { get; set; } = "ZR0";        // 外部タイマのデバイス
        public int PlcId { get; set; }                  // PLCのID
        public int? CycleId { get; set; }               // サイクルID
        public string? Comment1 { get; set; }           // コメント1
        public string? Comment2 { get; set; }           // コメント2
        public string? Comment3 { get; set; }           // コメント2

    }
}
