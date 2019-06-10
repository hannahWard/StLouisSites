using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSites.Models;

namespace StLouisSites.Data
{
    public class SpotRepository : ISpotRepository
    {
        
        private ApplicationDbContext context;

        public SpotRepository()
        {
        }

        public SpotRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Spot> GetSpots()
        {
            return context.Spots.ToList();
        }

        public int Save(Spot spot)
        {
            context.Add(spot);
            context.SaveChanges();
            return spot.Id;
        }
    }
}
