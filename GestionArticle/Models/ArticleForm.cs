using Microsoft.AspNetCore.Mvc;
using ModelGlobal_DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionArticle.Models
{
    public class ArticleForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string EAN13 { get; set; }
        public string Description { get; set; }

        public IEnumerable<Category>? CategoryList { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
