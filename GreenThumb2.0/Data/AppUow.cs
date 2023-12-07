using GreenThumb2._0.Models;
using GreenThumb2._0.Repositories;

namespace GreenThumb2._0.Data
{
    internal class AppUow
    {
        private readonly AppDbContext _context;

        public PlantRepository<PlantModel> PlanetRepository { get; set; }
        public InstructionRepository<InstructionModel> InstructionRepository { get; set; }

        public AppUow(AppDbContext context)
        {
            _context = context;
            PlanetRepository = new(context);
            InstructionRepository = new(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }


}
