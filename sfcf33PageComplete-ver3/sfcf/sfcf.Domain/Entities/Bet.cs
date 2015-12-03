
namespace sfcf.Domain.Entities
{
    public class Bet
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int OptionID { get; set; }
        public int Size { get; set; }

        public virtual User User { get; set; }
        public virtual Option Option { get; set; }
    }
}
