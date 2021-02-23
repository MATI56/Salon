using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonV2.Models;

namespace SalonV2.Data
{
    public class SalonV2Context : DbContext
    {
        public SalonV2Context (DbContextOptions<SalonV2Context> options)
            : base(options)
        {
        }

        public DbSet<SalonV2.Models.Klienci> Klienci { get; set; }

        public DbSet<SalonV2.Models.Uslugi> Uslugi { get; set; }
    }
}
