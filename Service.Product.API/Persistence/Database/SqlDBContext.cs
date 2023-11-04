using Microsoft.EntityFrameworkCore;
using Service.API.Entities;
using Service.API.Persistence.Mappings;

namespace Service.API.Persistence.Database
{
    public class SqlDBContext : DbContext
    {
        public SqlDBContext(DbContextOptions<SqlDBContext> options) : base(options)
        { }
        public DbSet<GetProdutResponse> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetProdutResponse>(e => new ProductMap(e));
        }
    }
}
