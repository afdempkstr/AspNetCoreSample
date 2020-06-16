using AspNetCoreSample.Models;

namespace AspNetCoreSample.ViewModels
{
    public class SelectedTeamViewModel
    {
        public SelectedTeam SelectedTeam { get; set; }

        public decimal SelectedTeamTotalOffer { get; set; }

        public decimal SelectedTeamTotalRating { get; set; }
    }
}
