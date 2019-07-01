using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Models
{
    public class CategorySpot : IModel
    {
        public int Id { get; set; }
        public int SpotId { get; set; }
        public int CategoryId { get; set; }
        public virtual Spot Spot { get; set; }
        public virtual Category Category { get; set; }
    }
}
