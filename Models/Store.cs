using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    class Store
    {
        public string StoreId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
