using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.IO;

namespace HX1584_HFT_2023241.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customer_id { get;set; }
        public int cart_id { get;set; }
        public string name { get;set;}
        public int phone { get;set;}
        public string city { get;set;}
        public int year { get;set;}

        [NotMapped]
        [ForeignKey(nameof(Cart))]

        public virtual Cart Cart { get; set; }


        public Customer(int customer_id, int cart_id, string name, int phone, string city, int year)
        {
            this.customer_id = customer_id;
            this.cart_id = cart_id;
            this.name = name;
            this.phone = phone;
            this.city = city;
            this.year = year;
        }

        public Customer()
        {

        }

        public override bool Equals(object obj)
        {
            Customer b = obj as Customer;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.customer_id == b.customer_id;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.customer_id);
        }
    }
}
