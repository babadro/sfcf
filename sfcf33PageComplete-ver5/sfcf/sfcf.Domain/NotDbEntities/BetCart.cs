using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sfcf.Domain.Entities;

namespace sfcf.Domain.NotDbEntities
{
    public class BetCart
    {
        private List<BetDraft> betDraftCollection = new List<BetDraft>();

        public void AddBetDraft(Option option, int? size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException("size", "Bet size must be equal or greater than zero!");
            BetDraft sameVotingDraft = betDraftCollection.Where(b => b.Option.VotingID == option.VotingID).FirstOrDefault();

            if (sameVotingDraft != null)
            {
                betDraftCollection.RemoveAll(b => b.Option.VotingID == option.VotingID);
            } 
        
            betDraftCollection.Add(new BetDraft
            {
                Option = option,
                Size = size
            });
            
        }

        public void RemoveDraft(Option option)
        {
            betDraftCollection.RemoveAll(b => b.Option.ID == option.ID);
        }

        public int? TotalSize()
        {
            return betDraftCollection.Sum(b => b.Size);
        }

        public void Clear()
        {
            betDraftCollection.Clear();
        }

        public IEnumerable<BetDraft> BetDrafts
        {
            get { return betDraftCollection; }
        }

    }

    public class BetDraft
    {
        public Option Option { get; set; }
        public int? Size { get; set; }
    }

}
