namespace Kdx.Contracts.DTOs
{
    public class ProcessDetailFinish
    {
        public int Id { get; set; }

        // CycleIdはProcessDetailFinishテーブルには存在しない
        // ProcessDetailテーブル経由で取得する必要がある
        public int ProcessDetailId { get; set; }

        public int? FinishProcessDetailId { get; set; }
    }
}
