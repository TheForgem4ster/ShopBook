namespace DataLayer.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string shortDesc { get; set; }
        public string grade { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavourite { get; set; }
        public bool available { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }

    }
}
