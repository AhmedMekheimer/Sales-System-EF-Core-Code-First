using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    class Sale
    {
        public string SaleId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        public string CustomerId { get; set; }  //FK
        public Customer Customer { get; set; } = null!; //A Sale must refer to a customer, easier in joins
        public string StoreId { get; set; } //FK
        public Store Store { get; set; } = null!;   //A Sale must refer to a store, easier in joins
        //A Sale contains many products
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        
    }
}
