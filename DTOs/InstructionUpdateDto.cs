using System.ComponentModel.DataAnnotations;

namespace smoking_meat_api.DTOs
{
    public class InstructionUpdateDto
    {
        [Required]
        public string Meat { get; set; }

        [Required]
        public int SmokingTemp { get; set; }

        [Required]
        public string CookTime { get; set; }

        [Required]
        public int CookedTemperature { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }

        public string Category { get; set; }
    }

}