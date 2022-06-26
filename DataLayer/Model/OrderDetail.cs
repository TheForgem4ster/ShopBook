using System.Collections.Generic;
using System;

namespace DataLayer.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId{ get; set; }
        public uint Price { get; set; }
        public Book book { get; set; }
        public Order order { get; set; }

    }
}
