using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        //[Key]
        //[ScaffoldColumn(false)] // 脚手架时不加此属性文本框
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")] // 使EF Core可以将Price正确映射到数据库中的货币
        public decimal Price { get; set; }

        // [Required]
        // [StringLength(5)]
        // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        // public string Rating { get; set; }
    }
}