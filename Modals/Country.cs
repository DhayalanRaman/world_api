using System.ComponentModel.DataAnnotations;

namespace World.Api.Modals
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(6)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }

    }
}
