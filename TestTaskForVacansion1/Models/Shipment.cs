using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace TestTaskForVacansion1.Models
{
    [Table(Name = "Shipments")]
    public class Shipment
    {
        [Browsable(false)]
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [DisplayName("Дата реєстрації")]
        [Column(Name = "RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Організація")]
        [Column(Name = "Organization")]
        public string Organization { get; set; }

        [DisplayName("Місто")]
        [Column(Name = "City")]
        public string City { get; set; }

        [DisplayName("Країна")]
        [Column(Name = "Country")]
        public string Country { get; set; }

        [DisplayName("Менеджер")]
        [Column(Name = "Manager")]
        public string Manager { get; set; }

        [DisplayName("Кількість")]
        [Column(Name = "Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Ціна")]
        [Column(Name = "Price", DbType = "money")]
        public decimal Price { get; set; }
    }
}
