using System.Collections.Generic;

namespace Models.Entities
{
    public class Author : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Bio { get; set; }

        public IList<Book> Books { get; set; }

    }
}
