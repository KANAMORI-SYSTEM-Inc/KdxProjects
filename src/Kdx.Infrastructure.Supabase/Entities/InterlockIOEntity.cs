using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("InterlockIO")]
    internal class InterlockIOEntity : BaseModel
    {
        [PrimaryKey("PlcId")]
        [Column("PlcId")]
        public int PlcId { get; set; }

        [PrimaryKey("IOAddress")]
        [Column("IOAddress")]
        public string? IOAddress { get; set; }

        [PrimaryKey("InterlockConditionId")]
        [Column("InterlockConditionId")]
        public int InterlockConditionId { get; set; }

        [Column("IsOnCondition")]
        public bool IsOnCondition { get; set; }

        [Column("ConditionUniqueKey")]
        public int ConditionUniqueKey { get; set; }

        public static InterlockIOEntity FromDto(InterlockIO dto) => new()
        {
            PlcId = dto.PlcId,
            IOAddress = dto.IOAddress,
            InterlockConditionId = dto.InterlockConditionId,
            IsOnCondition = dto.IsOnCondition,
            ConditionUniqueKey = dto.ConditionUniqueKey
        };

        public InterlockIO ToDto() => new()
        {
            PlcId = this.PlcId,
            IOAddress = this.IOAddress,
            InterlockConditionId = this.InterlockConditionId,
            IsOnCondition = this.IsOnCondition,
            ConditionUniqueKey = this.ConditionUniqueKey
        };
    }
}
