using System.ComponentModel.DataAnnotations;

namespace GamersShopingListC_MVC.Models.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public double Value { get; set; }
    }
}
