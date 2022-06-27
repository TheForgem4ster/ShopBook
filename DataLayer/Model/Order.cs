using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    /// <summary>
    /// Класс заказы, который содержит индификационный код, имя, фамилия, адресс, номер телефона
    /// почта, время заказа - с ограничениями ввода и лист деталей заказа
    /// Лист книг 
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Атрибут BindNever указывает, что свойство модели надо исключить из механизма привязки.
        /// </summary>
        [BindNever]
        
        /// <summary>
        /// Индификационный код заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// С помощью Display отображем текст
        /// </summary>
        [Display(Name = "Enter your name")]// Что будет отображаться в поле имя
        
        /// <summary>
        /// С помщью StringLength задаем ограничения в 20 символов
        /// </summary>      
        [StringLength(20)] // длина имени должна быть больше 20 символов
        
        /// <summary>
        /// С помощью абрибута валидации Required то что свойство должно быть установленно и вслучии null 
        /// выводит текст
        /// </summary>
        [Required(ErrorMessage = "Name length must be less than 20 characters")]
        
        /// <summary>
        /// Имя заказчика
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// С помощью Display отображем текст
        /// </summary>
        [Display(Name = "Enter last name")]

        /// <summary>
        /// С помщью StringLength задаем ограничения в 20 символов
        /// </summary> 
        [StringLength(20)]

        /// <summary>
        /// С помощью абрибута валидации Required то что свойство должно быть установленно и вслучии null 
        /// выводит текст
        /// </summary>
        [Required(ErrorMessage = "last name length must be less than 20 characters")]

        /// <summary>
        /// Фамилия заказчика
        /// </summary>
        public string SurName { get; set; }
        
        /// <summary>
        /// С помощью Display отображем текст
        /// </summary>
        [Display(Name = "Enter address")]

        /// <summary>
        /// С помщью StringLength задаем ограничения в 25 символов
        /// </summary> 
        [StringLength(25)]

        /// <summary>
        /// С помощью абрибута валидации Required то что свойство должно быть установленно и вслучии null 
        /// выводит текст
        /// </summary>
        [Required(ErrorMessage = "address length must be less than 25 characters")]

        /// <summary>
        /// Адресс заказчика
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// С помощью Display отображем текст
        /// </summary>
        [Display(Name = "Enter phone number")]

        /// <summary>
        /// С помщью StringLength задаем ограничения в 10 символов
        /// </summary> 
        [StringLength(10)] // длина имени должна быть больше 10 символов

        /// <summary>
        /// Атрибут DataType позволяет предоставлять среде выполнения информацию об использовании 
        /// свойства - отображает номер телефона
        /// </summary> 
        [DataType(DataType.PhoneNumber)]
        
        /// <summary>
        /// С помощью абрибута валидации Required то что свойство должно быть установленно и вслучии null 
        /// выводит текст
        /// </summary>
        [Required(ErrorMessage = "phone number length must be less than 10 characters")]
        
        /// <summary>
        /// Номер телефона заказчика
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// С помощью Display отображем текст
        /// </summary>
        [Display(Name = "Enter Email")]

        /// <summary>
        /// Атрибут DataType позволяет предоставлять среде выполнения информацию об использовании 
        /// свойства - отображает электронный адрес
        /// </summary>
        [DataType(DataType.EmailAddress)]

        /// <summary>
        /// С помщью StringLength задаем ограничения в 20 символов
        /// </summary> 
        [StringLength(20)] // длина имени должна быть больше 20 символов

        /// <summary>
        /// С помощью абрибута валидации Required то что свойство должно быть установленно и вслучии null 
        /// выводит текст
        /// </summary>
        [Required(ErrorMessage = "Email length must be less than 20 characters")]
        
        /// <summary>
        /// Почта заказчика
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Атрибут BindNever указывает, что свойство модели надо исключить из механизма привязки.
        /// </summary>
        [BindNever]

        /// <summary>
        /// Атрибут ScaffoldColumn указывает, что данное поле нельзя посмотреть через страничку 
        /// (скрываем)
        /// </summary>
        [ScaffoldColumn(false)]// Поле которое не было отображено в искодном коде
        
        /// <summary>
        /// Время заполнения заказа
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// Список деталий заказа
        /// </summary>
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
