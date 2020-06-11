using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSample.Models;
using AspNetCoreSample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ViewResult List()
        {
            var candidates = _candidateRepository.AllCandidates;

            var vm = new CandidateListViewModel()
            {
                Candidates = candidates,
                Header = "List of candidates"
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