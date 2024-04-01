namespace WebMVCTest.Models
{
    public class GameDevice 
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int DeviceID { get; set; }
        public Device Device { get; set; }

    }
}
