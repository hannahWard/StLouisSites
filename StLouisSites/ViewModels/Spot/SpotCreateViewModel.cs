using StLouisSites.Data;
using StLouisSites.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Spot
{
    public class SpotCreateViewModel
    {
        //private readonly RepositoryFactory repositoryFactory;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SpotCreateViewModel()
        {

        }

        //public SpotCreateViewModel(RepositoryFactory repositoryFactory)
        //{
        //    this.repositoryFactory = repositoryFactory;
        //}

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Models.Spot spot = new Models.Spot
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
            repositoryFactory.GetSpotRepository().Save(spot);



        }
    }
}
