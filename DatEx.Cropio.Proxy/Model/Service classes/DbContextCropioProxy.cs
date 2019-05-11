using Microsoft.AspNet.OData.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatEx.Cropio.Proxy.Model
{
    public class DbContextCropioProxy : DbContext
    {
        public DbContextCropioProxy(DbContextOptions<DbContextCropioProxy> options) : base(options)
        {

        }

        public DbSet<Alert> Alerts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Alert>().HasOne(p => p.CreatedByUser);
            modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedNever();
        }

        internal static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Alert>("Alerts").EntityType.Filter().Count().Expand().Filter().OrderBy().Page().Select();

            builder.EntitySet<User>("Users").EntityType.Filter().Count().Expand().Filter().OrderBy().Page().Select();
            //
            return builder.GetEdmModel();
        }
    }
}
