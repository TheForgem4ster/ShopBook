using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Enter your name")]// Что будет отображаться в поле имя
        [StringLength(20)] // длина имени должна быть больше 20 символов
        [Required(ErrorMessage = "Name length must be less than 20 characters")]
        public string Name { get; set; }

        [Display(Name = "Enter last name")]
        [StringLength(20)] 
        [Required(ErrorMessage = "last name length must be less than 20 characters")]
        public string SurName { get; set; }

        [Display(Name = "Enter address")]
        [StringLength(25)] 
        [Required(ErrorMessage = "address length must be less than 25 characters")]
        public string Adress { get; set; }

        [Display(Name = "Enter phone number")]
        [StringLength(10)] // длина имени должна быть больше 10 символов
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "phone number length must be less than 10 characters")]
        public string Phone { get; set; }

        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)] // длина имени должна быть больше 15 символов
        [Required(ErrorMessage = "Email length must be less than 10 characters")]
        public string Email { get; set; }       
        
        [BindNever]
        [ScaffoldColumn(false)]// Поле которое не было отображено в искодном коде
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
