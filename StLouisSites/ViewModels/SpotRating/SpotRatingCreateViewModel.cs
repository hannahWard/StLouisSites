using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisSites.Data;
using StLouisSites.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.SpotRating
{
    public class SpotRatingCreateViewModel
    {
      
        public int Id { get; set; }
        public int Rating { get; set; }
        public int SpotId { get; set; }
        public string Review { get; set; }


        internal void Persist(RepositoryFactory repositoryFactory)
        {
            Models.SpotRating rating = new Models.SpotRating
            {
                SpotId = this.SpotId,
                Rating = this.Rating,
                Review = this.Review
            };
            repositoryFactory.GetSpotRatingRepository().Save(rating);
        }
    }

    
}
