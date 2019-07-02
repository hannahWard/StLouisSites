using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisSites.Data;
using StLouisSites.Data.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Spot
{
    public class SpotCreateViewModel
    {
        [Display(Name = "Select Categories")]
        public List<int> CategoryIds { get; set; }
        public List<Models.Category> Categories { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "Description must be between 2-200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select County")]
        public string County { get; set; }
        
        public SpotCreateViewModel()
        {

        }

        public SpotCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.Categories = GetCategoryList(repositoryFactory);
        }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Models.Spot spot = new Models.Spot
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County
            };
            List<Models.CategorySpot> categorySpots = CreateManyToManyRelationships(spot.Id);
            spot.CategorySpots = categorySpots;
            repositoryFactory.GetSpotRepository().Save(spot);
        }

        private List<Models.Category> GetCategoryList(RepositoryFactory repositoryFactory)
        {
            return repositoryFactory.GetCategoryRepository()
                .GetModels().ToList();
        }

        private List<Models.CategorySpot> CreateManyToManyRelationships(int spotId)
        {
            return CategoryIds.Select(catId => new Models.CategorySpot { SpotId = spotId, CategoryId = catId }).ToList();
        }
    }
}
