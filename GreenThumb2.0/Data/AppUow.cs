using GreenThumb2._0.Models;
using GreenThumb2._0.Repositories;

namespace GreenThumb2._0.Data
{
    //Was gonna use Unit of Work. Didnt happen. 
    internal class AppUow
    {
        private readonly AppDbContext _context;

        public PlantRepository<PlantModel> PlanetRepository { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }


}
