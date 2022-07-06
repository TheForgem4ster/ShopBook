using DataLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DataLayer
{
    /// <summary>
    /// The class is used to add products
    /// </summary>
    [Table("InstitucionesMilitares", Schema = "configuracion")]
    public static class DBObjects
    {
        /// <summary>
        /// The method is used to add data to the database
        /// </summary>
        /// <param name="content"></param>
        public static void Initial(AppDBContent content)
        {

            // If the categories are empty we add them
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(con => con.Value));
            }

            // If the books are empty add them
            if (!content.Books.Any())
            {
                content.AddRange
                (
                    new Book
                    {
                        Name = "The Truth About the Harry Quebert Affair",
                        shortDesc = "Wherever you run, your problems get into your luggage and follow you everywhere.",
                        //Куда бы вы ни бежали, ваши проблемы залезают к вам в багаж и следуют за вами повсюду.
                        grade = "7.6 из 10",
                        img = "/img/The_Truth_About_the_Harry_Quebert_Affair_book.jpg",
                        price = 300,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Detective"]
                    },
                    new Book
                    {
                        Name = "Father Brown's Mystery",
                        shortDesc = "Can you define a crime by ear?",//А вы можете определить преступление на слух?
                        grade = "8 из 10",
                        img = "/img/Father_Brown_Mystery_book.jpg",
                        price = 130,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Detective"]
                    },
                    new Book
                    {
                        Name = "The Shining Stephen King",
                        shortDesc = "A promise is, of course, not a trifle",//Обещание — это, разумеется не пустяк.
                        grade = "9.6 из 10",
                        img = "/img/The_Shining_Stephen_King_book.jpg",
                        price = 240,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Horror"]
                    },
                    new Book
                    {
                        Name = "Shop of bad dreams",
                        shortDesc = "A story is like a football or basketball game: you compete not only with the opposing team, but also against time.",
                        //Рассказ – это футбольный или баскетбольный матч: ты соревнуешься не только с командой соперников, но и со временем.
                        grade = "8.7 из 10",
                        img = "/img/Shop_of_bad_dreams_book.jpg",
                        price = 350,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Horror"]
                    }
                );
            }

            // save all changes
            content.SaveChanges();
        }
        /// <summary>
        /// Dictionary for categories
        /// </summary>
        public static Dictionary<string, Category> categorys;
        /// <summary>
        /// The method is used to add categories to the database
        /// </summary>
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(categorys == null)
                {
                    var list = new Category[]
                    {
                        new Category { 
                            CategoryName = "Detective", 
                            Desc= "This is an investigation. We follow the detective looking for a clue"
                            //Это расследование. Следим за тем, как детектив ищет разгадку
                        },
                        new Category { 
                            CategoryName = "Horror", 
                            Desc= "They frighten with surprise, abomination, put pressure on universal or specific fears and phobias"
                            //Пугают неожиданностью, мерзостью, давят на общечеловеческие или конкретные страхи и фобии
                        }
                    };
                    categorys = new Dictionary<string, Category>();
                    foreach(Category element in list)
                    {
                        categorys.Add(element.CategoryName, element);
                    }
                }
                return categorys;
            }
        }
    }
}
