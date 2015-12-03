using sfcf.Domain.Entities;
using sfcf.Domain.Abstract;
using System.Linq;

namespace sfcf.Domain.Concrete
{
    public class EFRepository : IRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Bet> Bets
        {
            get { return context.Bets; }
        }

        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }
        
        public IQueryable<Option> Options
        {
            get { return context.Options; }
        }

        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public IQueryable<Voting> Votings
        {
            get { return context.Votings; }
        }
    }
}
