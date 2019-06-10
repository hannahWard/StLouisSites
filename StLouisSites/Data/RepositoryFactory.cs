using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Data
{
    public static class RepositoryFactory
    {
        private static ISpotRepository spotRepository;

        public static ISpotRepository GetSpotRepository()
        {
            if (spotRepository == null)
                spotRepository = new SpotRepository();
            return spotRepository;
        }
    }
}
