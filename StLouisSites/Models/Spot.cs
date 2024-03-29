﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Models
{
    public class Spot : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public virtual List<SpotRating> Ratings { get; set; }
        public virtual List<CategorySpot> CategorySpots { get; set; }
    }
}
