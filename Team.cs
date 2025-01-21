using System.ComponentModel.DataAnnotations;

namespace UkasNøttBackend
{
    public class Team
    {
        [Key]
        public int TeamNumber { get; set; }
        public string TeamName { get; set; }
    }
}
