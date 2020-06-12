using AspNetCoreSample.Models;
using AspNetCoreSample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;

        public HomeController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel()
            {
                Header = "Popular candidates",
                PopularCandidates = _candidateRepository.PopularCandidates()
            };

            return View(model);
        }
    }
}
