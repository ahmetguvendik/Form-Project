using System.ComponentModel.DataAnnotations;

namespace Form_Project.Models.Form
{
    public class CreateFormModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreatedAt { get; set; }

    }
}
