using System.ComponentModel.DataAnnotations;

namespace MVC_060223.Models
{
    public class FilmDuzenleViewModel
    {
        public int Id { get; set; }

        [MaxLength(400)]
        public string Ad { get; set; } = null!;

        public int Yil { get; set; }

        [Required]
        public decimal? Puan { get; set; }

        public int[] Turler { get; set; } = Array.Empty<int>();
    }
}
