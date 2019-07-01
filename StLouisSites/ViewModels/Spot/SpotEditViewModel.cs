using Microsoft.AspNetCore.Mvc.Rendering;
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
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; }

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
            Models.Spot spot = repositoryFactory.GetSpotRepository().GetById(spotId);
            this.Name = spot.Name;
            this.Description = spot.Description;
            this.Address = spot.Address;
            this.County = spot.County;
        }

        public void Update(int id, RepositoryFactory repositoryFactory)
        {
            Models.Spot spot = new Models.Spot
            {
                Id = id,
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County
            };
            repositoryFactory.GetSpotRepository().Update(spot);
        }
     
        private SelectList GetCategoryList(RepositoryFactory repositoryFactory)
        {
            var categories = repositoryFactory.GetCategoryRepository()
                .GetModels();
            return new SelectList(categories, "Id", "Name", this.CategoryId);
        }
    }
}
