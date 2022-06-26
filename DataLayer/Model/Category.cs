using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
        public List<Book> Books { get; set; }
    }
}
