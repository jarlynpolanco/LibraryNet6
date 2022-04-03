using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
