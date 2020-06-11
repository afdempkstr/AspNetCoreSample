using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSample.Models;
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
            return View(candidates);
        }
    }
}