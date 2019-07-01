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
        public int Id { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

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
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County
            };
            repositoryFactory.GetSpotRepository().Save(spot);
        }

        private IEnumerable<SelectListItem> GetCategoryList(RepositoryFactory repositoryFactory)
        {
            return repositoryFactory.GetCategoryRepository()
                .GetModels()
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()));
        }
    }
}
