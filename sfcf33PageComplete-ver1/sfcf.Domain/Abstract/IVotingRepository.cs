using sfcf.Domain.Entities;
using System.Linq;

namespace sfcf.Domain.Abstract
{
    public interface IVotingRepository
    {
        IQueryable<Voting> Votings { get; }
    }
}
