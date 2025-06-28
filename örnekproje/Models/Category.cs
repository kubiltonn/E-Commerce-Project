using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace örnekproje.Models
{
	public class Category
	{
        [Key]
        public int CategoryNo { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(100)]
        public string CategoryName { get; set; }

      
    }
}

