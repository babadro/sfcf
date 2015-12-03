using sfcf.Domain.Entities;
using System.Linq;

namespace sfcf.Domain.Abstract
{
    public interface IRepository
    {
        IQueryable<Bet> Bets { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Option> Options { get; }
        IQueryable<User> Users { get; }
        IQueryable<Voting> Votings { get; }
    }
}
