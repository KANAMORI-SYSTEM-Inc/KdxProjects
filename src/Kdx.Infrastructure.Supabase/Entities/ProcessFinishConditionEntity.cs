using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("ProcessFinishCondition")]
    internal class ProcessFinishConditionEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("CycleId")]
        public int? CycleId { get; set; }

        [Column("ProcessId")]
        public int ProcessId { get; set; }

        [Column("FinishProcessDetailId")]
        public int FinishProcessDetailId { get; set; }

        [Column("FinishSensor")]
        public string? FinishSensor { get; set; }

        public static ProcessFinishConditionEntity FromDto(ProcessFinishCondition dto) => new()
        {
            Id = dto.Id,
            CycleId = dto.CycleId,
            ProcessId = dto.ProcessId,
            FinishProcessDetailId = dto.FinishProcessDetailId,
            FinishSensor = dto.FinishSensor
        };

        public ProcessFinishCondition ToDto() => new()
        {
            Id = this.Id,
            CycleId = this.CycleId,
            ProcessId = this.ProcessId,
            FinishProcessDetailId = this.FinishProcessDetailId,
            FinishSensor = this.FinishSensor
        };
    }
}
