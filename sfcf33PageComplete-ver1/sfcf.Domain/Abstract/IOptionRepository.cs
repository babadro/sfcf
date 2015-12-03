using sfcf.Domain.Entities;
using System.Linq;

namespace sfcf.Domain.Abstract
{
    public interface IOptionRepository
    {
        IQueryable<Option> Options { get; }
    }
}
