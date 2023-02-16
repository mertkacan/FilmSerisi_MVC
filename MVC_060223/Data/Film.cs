using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC_060223.Data
{
    public class Film
    {
        public int Id { get; set; }

        [MaxLength(400)]
        public string Ad { get; set; } = null!;

        public int Yil { get; set; }

        [Precision(3, 1)]
        public decimal Puan { get; set; }

        public List<Tur> Turler { get; set; } = new();

    }
}
