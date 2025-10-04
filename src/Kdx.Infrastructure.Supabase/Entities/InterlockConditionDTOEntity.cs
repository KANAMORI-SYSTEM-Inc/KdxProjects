using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("InterlockCondition")]
    internal class InterlockConditionDTOEntity : BaseModel
    {
        [PrimaryKey("InterlockId")] // 複合主キー
        [Column("InterlockId")]
        public int InterlockId { get; set; }

        [PrimaryKey("ConditionNumber")] // 複合主キー
        [Column("ConditionNumber")]
        public int ConditionNumber { get; set; }

        [PrimaryKey("InterlockSortId")] // 複合主キー
        [Column("InterlockSortId")]
        public int InterlockSortId { get; set; }

        [Column("ConditionTypeId")]
        public int? ConditionTypeId { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        public static InterlockConditionDTOEntity FromDto(InterlockConditionDTO dto) => new()
        {
            InterlockId = dto.InterlockId,
            ConditionNumber = dto.ConditionNumber,
            InterlockSortId = dto.InterlockSortId,
            ConditionTypeId = dto.ConditionTypeId,
            Name = dto.Name
        };

        public InterlockConditionDTO ToDto() => new()
        {
            InterlockId = this.InterlockId,
            ConditionNumber = this.ConditionNumber,
            InterlockSortId = this.InterlockSortId,
            ConditionTypeId = this.ConditionTypeId,
            Name = this.Name
        };
    }
}
