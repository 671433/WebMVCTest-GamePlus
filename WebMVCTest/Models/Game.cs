

namespace WebMVCTest.Models
{
    public class Game : BaseEntity
    {


        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Cover { get; set; } = string.Empty;

        //If the name of nagvation Category and foreignkey has the same name pluss Id CategoryId EF will understand that
        public int CategoryID { get; set; }


        public Category Category { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();



    
    }
}
