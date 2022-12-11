namespace TARge21Shop.Data
{
    public class TARge21ShopContext : DbContext
    {
        public TARge21ShopContext(DbContextOptions<TARge21ShopContext> options) 
        : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
    }
}
