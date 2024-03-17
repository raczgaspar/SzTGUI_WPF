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
    public class Item 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int item_id { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int year_of_man { get; set; }
        public string fabr_country { get; set; }


        [NotMapped]
        [JsonIgnore]
        [ForeignKey(nameof(Order))]

        public virtual ICollection<Order> Order { get; set; }


        public Item(int item_id, string productName, int price, int year, string fabr_country)
        {
            this.item_id = item_id;
            this.productName = productName;
            this.price = price;
            this.year_of_man = year;
            this.fabr_country = fabr_country;
        }

        public Item()
        {

        }
    }
}
