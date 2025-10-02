using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("InterlockCondition")]
    internal class InterlockConditionEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("InterlockId")]
        public int InterlockId { get; set; }

        [Column("ConditionNumber")]
        public int ConditionNumber { get; set; }

        [Column("ConditionTypeId")]
        public int ConditionTypeId { get; set; }

        public static InterlockConditionEntity FromDto(InterlockCondition dto) => new()
        {
            Id = dto.Id,
            InterlockId = dto.InterlockId,
            ConditionNumber = dto.ConditionNumber,
            ConditionTypeId = dto.ConditionTypeId
        };

        public InterlockCondition ToDto() => new()
        {
            Id = this.Id,
            InterlockId = this.InterlockId,
            ConditionNumber = this.ConditionNumber,
            ConditionTypeId = this.ConditionTypeId
        };
    }
}
