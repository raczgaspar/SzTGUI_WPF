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
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cart_ID { get; set; }
        public string comment { get; set; }
        public bool delivered { get; set; }
        public int priority { get; set; }

        [NotMapped]
        [JsonIgnore]
        [ForeignKey(nameof(Customer))]

        public virtual ICollection<Customer> Customers { get; set; }

        [NotMapped]
        [ForeignKey(nameof(Order))]

        public virtual ICollection<Order> Orders { get; set; }



        public Cart(int cart_ID, string comment, bool delivered, int priority)
        {
            this.cart_ID = cart_ID;
            this.comment = comment;
            this.delivered = delivered;
            this.priority = priority;
        }
        public Cart()
        {
            this.comment = "";
        }

        public override bool Equals(object obj)
        {
            Cart b = obj as Cart;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.cart_ID == b.cart_ID;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.cart_ID);
        }
    }
}
