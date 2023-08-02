using System.ComponentModel.DataAnnotations;

namespace FileUpload.ViewModels
{
    public class CreateProductVM
    {

        [Required(ErrorMessage = "{0} alanı zorunlu")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunlu")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunlu")]
        [Display(Name = "Fiyat")]
      
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "{0} alanı zorunlu")]
        [Display(Name = "ResimUrl")]
        public IFormFile ImageUrl { get; set; }
    }
}
