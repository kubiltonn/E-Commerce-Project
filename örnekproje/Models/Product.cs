using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace örnekproje.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(100)]
        public string?ProductName { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock zorunludur")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok 0 veya daha büyük olmalıdır.")]
        public int Stock { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public string ? ImageUrl { get; set; }

        [ForeignKey("Category")]
        public int CategoryNo { get; set; }

        public virtual Category ?Category { get; set; }



    }
}

