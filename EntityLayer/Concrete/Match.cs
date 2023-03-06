using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public int? HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public string MatchDate { get; set; }
        public string Stadium { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
    }
}
