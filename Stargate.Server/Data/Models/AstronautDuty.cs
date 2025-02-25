using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stargate.Server.Data.Models
{
    [Table("AstronautDuty")]
    public class AstronautDuty
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Rank { get; set; } = string.Empty;

        // ochia - property name doesn't need duty in it". This is redundant.
        public string DutyTitle { get; set; } = string.Empty;

        // ochia - property name doesn't need duty in it". This is redundant.
        public DateTime DutyStartDate { get; set; }
        
        // ochia - property name doesn't need duty in it". This is redundant.
        public DateTime? DutyEndDate { get; set; }

        public virtual Person Person { get; set; }
    }

    public class AstronautDutyConfiguration : IEntityTypeConfiguration<AstronautDuty>
    {
        public void Configure(EntityTypeBuilder<AstronautDuty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
