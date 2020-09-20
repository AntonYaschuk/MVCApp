using System;
using System.Collections.Generic;

namespace LibraryMVC
{
    public partial class ReadersBooks
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime Issue { get; set; }
        public DateTime PlanReturn { get; set; }
        public int StatusId { get; set; }
        public DateTime? FactRetrun { get; set; }

        public virtual Books Book { get; set; }
        public virtual Readers Reader { get; set; }
        public virtual Statuses Status { get; set; }
    }
}
