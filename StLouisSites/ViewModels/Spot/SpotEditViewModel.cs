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

        public SpotEditViewModel() { }

        public SpotEditViewModel(int spotId, RepositoryFactory repositoryFactory)
        {
            Models.Spot spot = repositoryFactory.GetSpotRepository().GetById(spotId);
            this.Name = spot.Name;
            this.Description = spot.Description;
            this.Address = spot.Address;
            this.County = spot.County;
            this.CategoryIds = spot.CategorySpots.Select(cs => cs.CategoryId).ToList();
            this.Categories = repositoryFactory.GetCategoryRepository().GetModels().ToList();
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
            List<Models.CategorySpot> categorySpots = CreateManyToManyRelationships(spot.Id, repositoryFactory);
            spot.CategorySpots = categorySpots;
            repositoryFactory.GetSpotRepository().Update(spot);
        }
     
        private List<Models.CategorySpot> CreateManyToManyRelationships(int spotId, RepositoryFactory repositoryFactory)
        {
            List<Models.CategorySpot> categorySpots = 
                repositoryFactory.GetCategorySpotRepository()
                .GetModels()
                .Where(s => s.SpotId == spotId)
                .ToList();

            foreach (var item in categorySpots)
            {
                repositoryFactory.GetCategorySpotRepository().DeleteManyToMany(item);
            }

            return CategoryIds
                .Select(catId => new Models.CategorySpot { SpotId = spotId, CategoryId = catId })
                .ToList();
            
        }
    }
}
