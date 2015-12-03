using sfcf.Domain.Entities;
using System.Linq;

namespace sfcf.Domain.Abstract
{
    public interface IBetRepository
    {
        IQueryable<Bet> Bets { get; }
    }
}
