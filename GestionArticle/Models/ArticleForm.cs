using Microsoft.AspNetCore.Mvc;
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
        public double Price { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string EAN13 { get; set; }
        public string Description { get; set; }
    }
}
