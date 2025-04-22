using System.ComponentModel.DataAnnotations;

namespace MiVivero.Client.Models.Forms
{
    public class CategoryNewFormModel
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
    }
}
