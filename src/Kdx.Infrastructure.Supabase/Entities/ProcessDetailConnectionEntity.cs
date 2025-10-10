using Postgrest.Attributes;
using Postgrest.Models;
using Kdx.Contracts.DTOs;

namespace Kdx.Infrastructure.Supabase.Entities
{
    [Table("ProcessDetailConnection")]
    internal class ProcessDetailConnectionEntity : BaseModel
    {
        [PrimaryKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("FromProcessDetailId")]
        public int FromProcessDetailId { get; set; }

        [Column("ToProcessDetailId")]
        public int? ToProcessDetailId { get; set; }

        public static ProcessDetailConnectionEntity FromDto(ProcessDetailConnection dto) => new()
        {
            Id = dto.Id,
            FromProcessDetailId = dto.FromProcessDetailId,
            ToProcessDetailId = dto.ToProcessDetailId
        };

        public ProcessDetailConnection ToDto() => new()
        {
            Id = this.Id,
            FromProcessDetailId = this.FromProcessDetailId,
            ToProcessDetailId = this.ToProcessDetailId
        };
    }
}
