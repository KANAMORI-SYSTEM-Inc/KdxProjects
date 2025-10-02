using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("ProsTimeDefinitions")]
    internal class ProsTimeDefinitionsEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("OperationCategoryId")]
        public int OperationCategoryId { get; set; }

        [Column("TotalCount")]
        public int TotalCount { get; set; }

        [Column("SortOrder")]
        public int SortOrder { get; set; }

        [Column("OperationDefinitionsId")]
        public int OperationDefinitionsId { get; set; }

        public static ProsTimeDefinitionsEntity FromDto(ProsTimeDefinitions dto) => new()
        {
            Id = dto.Id,
            OperationCategoryId = dto.OperationCategoryId,
            TotalCount = dto.TotalCount,
            SortOrder = dto.SortOrder,
            OperationDefinitionsId = dto.OperationDefinitionsId
        };

        public ProsTimeDefinitions ToDto() => new()
        {
            Id = this.Id,
            OperationCategoryId = this.OperationCategoryId,
            TotalCount = this.TotalCount,
            SortOrder = this.SortOrder,
            OperationDefinitionsId = this.OperationDefinitionsId
        };
    }
}
