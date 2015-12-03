using System.Linq;
using sfcf.Domain.Entities;

namespace sfcf.Domain.Abstract
{
    public interface ITerritoryRepository
    {
        IQueryable<Territory> Territories { get; }
    }
}
