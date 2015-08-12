using MitchellClaim.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaim.DataAccessLayer
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext():base("DBConnection")
        {

        }

        public DbSet<MitchellClaimType> MitchellClaimTypes { get; set; }
        public DbSet<LossInfoType> LossInfoTypes { get; set; }
        public DbSet<VehicleInfoType> VehicleInfoTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MitchellClaimType>().ToTable("MitchellClaim");
            modelBuilder.Entity<LossInfoType>().ToTable("LossInfo");
            modelBuilder.Entity<VehicleInfoType>().ToTable("VehicleInfo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
