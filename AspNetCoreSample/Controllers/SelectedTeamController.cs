using AspNetCoreSample.Models;
using AspNetCoreSample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Controllers
{
    public class SelectedTeamController : Controller
    {
        private readonly SelectedTeam _selectedTeam;
        private readonly ICandidateRepository _candidateRepository;

        public SelectedTeamController(SelectedTeam selectedTeam, ICandidateRepository candidateRepository)
        {
            _selectedTeam = selectedTeam;
            _candidateRepository = candidateRepository;
        }

        public IActionResult Index()
        {
            var vm = new SelectedTeamViewModel()
            {
                SelectedTeam = _selectedTeam,
                SelectedTeamTotalOffer = _selectedTeam.GetSelectedTeamTotalOffer(),
                SelectedTeamTotalRating = _selectedTeam.GetSelectedTeamTotalRating()
            };

            return View(vm);
        }

        public IActionResult AddToSelectedTeam(int candidateId, int offerPrice)
        {
            var candidate = _candidateRepository.AllCandidates.FirstOrDefault(c => c.Id == candidateId);

            if (candidate != null)
            {
                _selectedTeam.AddToTeam(candidate, offerPrice);
            }

            return RedirectToAction("Index");
        }

        [FeatureGate("RemoveCandidateFromSelectedTeam")]
        public IActionResult RemoveFromSelectedTeam(int candidateId)
        {
            var candidate = _candidateRepository.AllCandidates.FirstOrDefault(c => c.Id == candidateId);

            if (candidate != null)
            {
                _selectedTeam.RemoveFromTeam(candidate);
            }

            return RedirectToAction("Index");
        }
    }
}
