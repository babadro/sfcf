using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sfcf.Domain.Entities
{
    public class Voting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Option> Options { get; set; }
    }
}