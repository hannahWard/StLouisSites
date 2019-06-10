using StLouisSites.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Spot
{
    public class SpotListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<SpotListItemViewModel> GetSpotListItemsFromSpot(List<Models.Spot> spots)
        {
            List<SpotListItemViewModel> viewModelSpots = new List<SpotListItemViewModel>();
            foreach (var spot in spots)
            {
                SpotListItemViewModel model = new SpotListItemViewModel
                {
                    Id = spot.Id,
                    Name = spot.Name,
                    Description = spot.Description
                };
                viewModelSpots.Add(model);
            }
            return viewModelSpots;
           
        }

        //public static List<SpotListItemViewModel> GetSpotList()
        //{
        //    //return RepositoryFactory.GetSpotRepository()
        //    //    .GetSpots().Cast<SpotListItemViewModel>()
        //    //    .ToList();
        //    return RepositoryFactory.GetSpotRepository()
        //        .GetSpots().Select(spot => GetSpotListItemFromSpot(spot)).ToList();
        //}
    }
}
