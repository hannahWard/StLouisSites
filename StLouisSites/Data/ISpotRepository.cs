using StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Data
{
    public interface ISpotRepository
    {
        List<Spot> GetSpots();
        int Save(Spot spot);
    }
}
