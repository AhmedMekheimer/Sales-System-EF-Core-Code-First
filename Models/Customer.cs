using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    class Customer
    {
        public string CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(80)]
        [Column("Email",TypeName="varchar")]
        public string Email { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
