using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("ProcessDetailFinish")]
    internal class ProcessDetailFinishEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ProcessDetailId")]
        public int ProcessDetailId { get; set; }

        [Column("FinishProcessDetailId")]
        public int? FinishProcessDetailId { get; set; }

        public static ProcessDetailFinishEntity FromDto(ProcessDetailFinish dto) => new()
        {
            Id = dto.Id,
            ProcessDetailId = dto.ProcessDetailId,
            FinishProcessDetailId = dto.FinishProcessDetailId
        };

        public ProcessDetailFinish ToDto() => new()
        {
            Id = this.Id,
            ProcessDetailId = this.ProcessDetailId,
            FinishProcessDetailId = this.FinishProcessDetailId
        };
    }
}
