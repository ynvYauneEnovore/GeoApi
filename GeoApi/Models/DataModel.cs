using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataModel.Models
{
    public class DataModel
    {
        public Int64 id { get; set; }
        [Required]
        public string ip { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string currency_name { get; set; }
        public string currency_symbol { get; set; }
    }
}