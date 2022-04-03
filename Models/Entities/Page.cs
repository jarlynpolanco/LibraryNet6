using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Page : BaseEntity
    {
        public int PageNumber { get; set; }
        public string Content { get; set; }

        [Required]
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
