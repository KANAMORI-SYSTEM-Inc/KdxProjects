namespace Kdx.Contracts.DTOs
{
    public class ProsTimeDefinitions
    {
        public int Id { get; set; }
        public int OperationCategoryId { get; set; }
        public int TotalCount { get; set; }
        public int SortOrder { get; set; }
        public int OperationDefinitionsId { get; set; } // 外部キーとして OperationDefinitions テーブルの ID を参照
    }
}
