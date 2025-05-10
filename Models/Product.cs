using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    class Product
    {
        public string ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        //A product is purchased in many Sales مُشتريات
        [MaxLength(250)]
        [DefaultValue("No Description")]
        public string Description { get; set; }
    }
}
