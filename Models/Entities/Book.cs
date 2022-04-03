using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public double Price { get; set; }

        [Required]
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public IList<Page> Pages { get; set; }
    }
}
