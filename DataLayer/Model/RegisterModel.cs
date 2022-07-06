using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Model
{
    /// <summary>
    /// Class for registration in which there is an Email password and password confirmation
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Registration Email
        /// </summary>
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }
        /// <summary>
        /// Password for registration
        /// </summary>
        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// Confirm password for registration
        /// </summary>
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }
}
