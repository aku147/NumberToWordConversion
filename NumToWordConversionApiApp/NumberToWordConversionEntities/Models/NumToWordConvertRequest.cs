using System.ComponentModel.DataAnnotations;

namespace NumberToWordConversionEntities
{
    public class NumToWordConvertRequest
    {
        [Required]
        public string Input { get; set; }
    }
}