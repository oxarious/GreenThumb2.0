using System.ComponentModel.DataAnnotations;

namespace GreenThumb2._0.Models
{
    public class InstructionModel
    {
        [Key]
        public int InstructionId { get; set; }
        public string Instructions { get; set; } = null!;
        public int PlantId { get; set; }
        public PlantModel? Plant { get; set; }
    }
}
