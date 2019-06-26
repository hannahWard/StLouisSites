using StLouisSites.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Spot
{
    public class SpotEditViewModel
    {

        

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "Description must be between 2-200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select County")]
        public string County { get; set; }

        public SpotEditViewModel() { }

        public SpotEditViewModel(int spotId, RepositoryFactory repositoryFactory)
        {
            this.Id = spotId;
        }

        public void Update(int spotId, RepositoryFactory repositoryFactory)
        {
            Models.Spot spot = new Models.Spot
            {
                Id = spotId,
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County
            };
            repositoryFactory.GetSpotRepository().Save(spot);
        }
        //public void Update(int spotId, RepositoryFactory repositoryFactory)
        //{
        //    Models.Spot spot = repositoryFactory.GetSpotRepository().GetById(spotId);
        //    spot.Name = this.Name;
        //    spot.Description = this.Description;
        //    spot.Address = this.Address;
        //    spot.County = this.County;
        //    spot.Id = spotId;
        //    repositoryFactory.GetSpotRepository().Update(spot);
        //}
    }
}
