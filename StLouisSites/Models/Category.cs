using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Models
{
    public class Category : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<CategorySpot> CategorySpots { get; set; }
    }
}
