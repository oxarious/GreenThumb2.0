using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2._0.Models
{
    internal class PlantModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public DateTime PlantDate { get; set; }
        IEnumerable<InstructorModel> Instructions { get; set; }
    }
}
