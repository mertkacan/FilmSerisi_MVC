using MVC_060223.Data;

namespace MVC_060223.Models
{
    public class HomeViewModel
    {
        public List<Film> Filmler { get; set; } = new();
        public int? TurId { get; set; }
    }
}
