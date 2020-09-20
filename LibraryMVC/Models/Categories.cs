using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC
{
    public partial class Categories
    {
        public Categories()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не може бути порожнім")]
        [Display(Name = "Категорія")]
        public string Name { get; set; }
        [Display (Name = "Інформація про категорії")]
        public string Info { get; set; }
        

        public virtual ICollection<Books> Books { get; set; }
    }
}
