using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Spot
{
    public class SpotListItemViewModel
    {

        public static List<SpotListItemViewModel> GetSpots(RepositoryFactory factory)
        {
            return factory.GetSpotRepository()
                .GetModels()
                .Select(s => new SpotListItemViewModel(s))
                .ToList();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
       
        public SpotListItemViewModel(Models.Spot spot)
        {
            this.Id = spot.Id;
            this.Name = spot.Name;
            this.Description = spot.Description;
            if (spot.Ratings.Count() == 0)
            {
                this.AverageRating = 0;
            }
            else
            {
                this.AverageRating = Math.Round(spot.Ratings.Average(s => s.Rating), 2);
            }
            
        }

    }
}
