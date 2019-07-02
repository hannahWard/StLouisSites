using StLouisSites.Data.Repos;
using StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Data
{
    public class RepositoryFactory
    {
        private ApplicationDbContext context;

        public RepositoryFactory(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<SpotRating> GetSpotRatingRepository()
        {
            return new Repository<SpotRating>(context);
        }

        public IRepository<Spot> GetSpotRepository()
        {
            return new Repository<Spot>(context);
        }

        public IRepository<Category> GetCategoryRepository()
        {
            return new Repository<Category>(context);
        }

        public IRepository<CategorySpot> GetCategorySpotRepository()
        {
            return new Repository<CategorySpot>(context);
        }
    }
}
