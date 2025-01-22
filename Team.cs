using System.ComponentModel.DataAnnotations;

namespace UkasNøttBackend
{
    public class Team
    {
        public int Id { get; set; }
        public int TeamNumber { get; set; }
        public string TeamName { get; set; }
    }
}
