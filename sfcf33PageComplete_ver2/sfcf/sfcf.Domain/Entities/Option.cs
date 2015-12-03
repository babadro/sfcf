using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sfcf.Domain.Entities
{
    public class Option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int VotingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        public virtual Voting Voting { get; set; }
    }
}
