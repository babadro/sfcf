using System.Collections.Generic;

namespace sfcf.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        /*
        public virtual ICollection<Bet> Bets { get; set; }
         * */
    }
}
