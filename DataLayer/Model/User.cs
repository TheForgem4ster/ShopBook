using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
    /// <summary>
    /// User class that has ID, password, email, name, age
    /// </summary>
    public class User
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User age
        /// </summary>
        public int Age { get; set; }
        
    }
}
