using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("Interlock")]
    internal class InterlockEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("PlcId")]
        public int PlcId { get; set; }

        [Column("CylinderId")]
        public int CylinderId { get; set; }

        [Column("SortId")]
        public int SortId { get; set; }

        [Column("ConditionCylinderId")]
        public int ConditionCylinderId { get; set; }

        [Column("PreConditionID1")]
        public int? PreConditionID1 { get; set; }

        [Column("PreConditionID2")]
        public int? PreConditionID2 { get; set; }

        public static InterlockEntity FromDto(Interlock dto) => new()
        {
            Id = dto.Id,
            PlcId = dto.PlcId,
            CylinderId = dto.CylinderId,
            SortId = dto.SortId,
            ConditionCylinderId = dto.ConditionCylinderId,
            PreConditionID1 = dto.PreConditionID1,
            PreConditionID2 = dto.PreConditionID2
        };

        public Interlock ToDto() => new()
        {
            Id = this.Id,
            PlcId = this.PlcId,
            CylinderId = this.CylinderId,
            SortId = this.SortId,
            ConditionCylinderId = this.ConditionCylinderId,
            PreConditionID1 = this.PreConditionID1,
            PreConditionID2 = this.PreConditionID2
        };
    }
}
