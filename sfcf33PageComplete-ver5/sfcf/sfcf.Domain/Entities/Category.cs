using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sfcf.Domain.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Voting> Votings { get; set; }
    }
}
