using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
    public class Person
    {
        // Ид. Номер
        [Key]
        public int Inn { get; set; }

        //Имя и фамилия
        public string Name { get; set; }

        // адрес покупателя
        public string Address { get; set; }

        // Дата Рождения
        public DateTime DateBorn { get; set; }
    }
}