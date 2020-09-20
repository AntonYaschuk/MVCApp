using System;
using System.Collections.Generic;

namespace LibraryMVC
{
    public partial class Books
    {
        public Books()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
