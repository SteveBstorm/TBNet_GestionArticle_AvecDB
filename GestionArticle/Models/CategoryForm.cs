using System.ComponentModel.DataAnnotations;

namespace GestionArticle.Models
{
    public class CategoryForm
    {
        [Required]
        [Display(Name = "Nom de catégorie")]
        public string Name { get; set; }
    }
}
