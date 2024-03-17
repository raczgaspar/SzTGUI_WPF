using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HX1584_HFT_2023241.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_id { get; set; }
        public int item_id { get; set; }
        public int cart_id { get; set; }
        public int amount { get; set; }

        [NotMapped]
        [JsonIgnore]
        [ForeignKey(nameof(Cart))]
        public virtual Cart Cart { get; set; }
        [NotMapped]
        [ForeignKey(nameof(Item))]
        public virtual Item Item { get; set; }





        public Order(int order_id, int item_id, int cart_id, int amount)
        {
            this.order_id = order_id;
            this.item_id = item_id;
            this.cart_id = cart_id;
            this.amount = amount;
        }

        public Order()
        {

        }

        
    }
}
