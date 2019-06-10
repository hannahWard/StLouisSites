using StLouisSites.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Spot
{
    
    public class SpotCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public Models.Spot Persist()
        {
            Models.Spot spot = new Models.Spot
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
            return spot;


        }
    }
}
