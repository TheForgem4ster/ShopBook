using DataLayer.Models;
using System.Collections.Generic;


namespace WebApplication1.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> favBook { get; set; }
    }
}
