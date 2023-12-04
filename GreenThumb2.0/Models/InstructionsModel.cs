using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2._0.Models
{
    internal class InstructionModel
    {
        public int InstructionsId { get; set; }
        public string Instructions { get; set; } = null!;
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; }
    }
}
