using sfcf.Domain.Entities;
using System.Linq;

namespace sfcf.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
