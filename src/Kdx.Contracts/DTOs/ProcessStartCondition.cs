namespace Kdx.Contracts.DTOs
{
    /// <summary>
    /// 工程の開始条件を管理する中間テーブル
    /// ProcessテーブルのAutoConditionフィールド（複数値）を正規化したもの
    /// </summary>
    public class ProcessStartCondition
    {
        /// <summary>
        /// ID (主キー)
        /// </summary>
        public int Id { get; set; }

        public int? CycleId { get; set; }

        /// <summary>
        /// 工程ID
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// 開始条件となる工程詳細ID
        /// </summary>
        public int StartProcessDetailId { get; set; }

        /// <summary>
        /// 開始センサー（オプション）
        /// </summary>
        public string? StartSensor { get; set; }
    }
}