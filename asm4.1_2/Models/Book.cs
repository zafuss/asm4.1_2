namespace asm4._1_2.Models
{
    public class Book
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public double price{ get; set; }

        public string? author { get; set; } 

        public Book() { }


        public Book(int id, string? title, string? description, double price, string? imageUrl, string? author)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.price = price;
            this.imageUrl = imageUrl;
            this.author = author;
        }
    }
}
