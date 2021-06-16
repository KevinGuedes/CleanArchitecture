using CleanArchitecture.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Stock is Required")]
        [Range(1, Int32.MaxValue)]
        public int Stock { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        //public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
