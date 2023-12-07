using System.ComponentModel.DataAnnotations;

namespace GreenThumb2._0.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<InstructionModel>? Instructions { get; set; }


    }
}
