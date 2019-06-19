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
        private string ratings = "12345";
        private readonly RepositoryFactory repositoryFactory;

        public int Id { get; set; }
        public int Rating { get; set; }
        public int SpotId { get; set; }
        public SelectList Ratings { get { return GetRatings(); } }

       
        public SpotRatingCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        private SelectList GetRatings()
        {
            var ratingSelectListItems = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString()));
            return new SelectList(ratingSelectListItems);
        }

        internal void Persist()
        {
            Models.SpotRating rating = new Models.SpotRating
            {
                SpotId = this.SpotId,
                Rating = this.Rating
            };
            repositoryFactory.GetSpotRatingRepository().Save(rating);
        }
    }

    
}
