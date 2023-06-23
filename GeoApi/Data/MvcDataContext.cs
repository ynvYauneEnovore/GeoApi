using Microsoft.EntityFrameworkCore;
using GeoData.Models;

namespace GeoApi.Data
{
    public class MvcDataContext : DbContext
    {
        public MvcDataContext(DbContextOptions<MvcDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
        }
        public DbSet<GeoData> GeoData { get; set; }
    }
}
