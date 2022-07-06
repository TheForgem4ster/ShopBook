using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Model
{
    /// <summary>
    /// Class for login a site that has a password and email
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Email for login
        /// </summary>
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }
        /// <summary>
        /// Password for login
        /// </summary>
        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
