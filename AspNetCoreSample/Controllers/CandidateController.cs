using AspNetCoreSample.Models;
using AspNetCoreSample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreSample.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISpecialisationRepository _specialisationRepository;

        public CandidateController(ICandidateRepository candidateRepository, ISpecialisationRepository specialisationRepository)
        {
            _candidateRepository = candidateRepository;
            _specialisationRepository = specialisationRepository;
        }

        public ViewResult List(string specialisation)
        {
            IEnumerable<Candidate> candidates;
            string currentSpecialisation;

            if (string.IsNullOrWhiteSpace(specialisation))
            {
                candidates = _candidateRepository.AllCandidates.OrderBy(c => c.LastName);
                currentSpecialisation = "All candidates";
            }
            else
            {
                candidates = _candidateRepository.AllCandidates
                    .Where(c => c.Specialisation.Name == specialisation)
                    .OrderBy(c => c.LastName);
                currentSpecialisation = _specialisationRepository.AllSpecialisations
                    .FirstOrDefault(s => s.Name == specialisation)?.Name;
            }

            var vm = new CandidateListViewModel()
            {
                Candidates = candidates,
                CurrentSpecialisation = currentSpecialisation
            };
            ViewBag.Title = "Candidate Manager";

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var candidate = _candidateRepository.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }
    }
}