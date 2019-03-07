using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;




namespace MyOnlineShop.Core.Models
{
    public class Product
    {
        public string ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        public string Image { get; set; }

        public Product()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}