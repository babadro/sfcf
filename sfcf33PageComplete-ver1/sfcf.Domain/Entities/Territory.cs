using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/* Класс пока не используется */

namespace sfcf.Domain.Entities
{
    public class Territory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string iso3166_2 { get; set; }
        public string engName {get; set;} 
        public string nativeName {get; set;}

        public virtual ICollection<Voting> Votings { get; set; }
    }

}
