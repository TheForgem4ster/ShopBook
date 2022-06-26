using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace BusinessLayer.Repository
{
    public class CategoryRepository : IBooksCategory
    {
        private readonly AppDBContent _appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => _appDBContent.Category;
    }
}
