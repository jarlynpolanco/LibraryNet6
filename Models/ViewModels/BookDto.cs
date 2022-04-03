
namespace Models.ViewModels
{
    public class BookDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public double Price { get; set; }
    }
}
