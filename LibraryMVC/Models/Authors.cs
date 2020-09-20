using System;
using System.Collections.Generic;

namespace LibraryMVC
{
    public partial class Authors
    {
        public Authors()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
