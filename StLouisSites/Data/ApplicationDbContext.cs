using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StLouisSites.Models;

namespace StLouisSites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Spot> Spots { get; set; }
        public DbSet<SpotRating> SpotRatings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
