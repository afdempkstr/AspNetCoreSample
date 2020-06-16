using AspNetCoreSample.Models;
using AspNetCoreSample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Components
{
    public class SelectedTeamProfile : ViewComponent
    {
        private readonly SelectedTeam _selectedTeam;

        public SelectedTeamProfile(SelectedTeam selectedTeam)
        {
            _selectedTeam = selectedTeam;
        }

        public IViewComponentResult Invoke()
        {
            var vm = new SelectedTeamViewModel
            {
                SelectedTeam = _selectedTeam,
                SelectedTeamTotalOffer = _selectedTeam.GetSelectedTeamTotalOffer(),
                SelectedTeamTotalRating = _selectedTeam.GetSelectedTeamTotalRating()
            };

            return View(vm);
        }
    }
}
