using sfcf.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace sfcf.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Voting> Votings { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>(); ;
        }
    }
}
