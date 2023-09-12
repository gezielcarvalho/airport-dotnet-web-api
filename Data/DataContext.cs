using DotNetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; }
    }
}
