using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitTestingInDotNet.Models;

namespace UnitTestingInDotNet.Data
{
    public class UnitTestingInDotNetContext : DbContext
    {
        public UnitTestingInDotNetContext (DbContextOptions<UnitTestingInDotNetContext> options)
            : base(options)
        {
        }

        public DbSet<UnitTestingInDotNet.Models.Vehicle> Vehicle { get; set; } = default!;
        //public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Pass> Passes { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
