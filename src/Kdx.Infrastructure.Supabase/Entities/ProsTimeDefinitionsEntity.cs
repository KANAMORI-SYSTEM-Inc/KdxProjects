using Kdx.Contracts.DTOs;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("ProsTimeDefinitions")]
    internal class ProsTimeDefinitionsEntity : BaseModel
    {
        [Column("OperationCategoryId")]
        public int OperationCategoryId { get; set; }

        [Column("SortOrder")]
        public int SortOrder { get; set; }

        [Column("OperationDefinitionsId")]
        public int OperationDefinitionsId { get; set; }

        public static ProsTimeDefinitionsEntity FromDto(ProsTimeDefinitions dto) => new()
        {
            OperationCategoryId = dto.OperationCategoryId,
            SortOrder = dto.SortOrder,
            OperationDefinitionsId = dto.OperationDefinitionsId
        };

        public ProsTimeDefinitions ToDto() => new()
        {
            OperationCategoryId = this.OperationCategoryId,
            SortOrder = this.SortOrder,
            OperationDefinitionsId = this.OperationDefinitionsId
        };
    }
}
