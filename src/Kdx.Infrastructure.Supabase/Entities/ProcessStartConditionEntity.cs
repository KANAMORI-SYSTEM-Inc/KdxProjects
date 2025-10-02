using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("ProcessStartCondition")]
    internal class ProcessStartConditionEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("CycleId")]
        public int? CycleId { get; set; }

        [Column("ProcessId")]
        public int ProcessId { get; set; }

        [Column("StartProcessDetailId")]
        public int StartProcessDetailId { get; set; }

        [Column("StartSensor")]
        public string? StartSensor { get; set; }

        public static ProcessStartConditionEntity FromDto(ProcessStartCondition dto) => new()
        {
            Id = dto.Id,
            CycleId = dto.CycleId,
            ProcessId = dto.ProcessId,
            StartProcessDetailId = dto.StartProcessDetailId,
            StartSensor = dto.StartSensor
        };

        public ProcessStartCondition ToDto() => new()
        {
            Id = this.Id,
            CycleId = this.CycleId,
            ProcessId = this.ProcessId,
            StartProcessDetailId = this.StartProcessDetailId,
            StartSensor = this.StartSensor
        };
    }
}
