using AspNetCoreSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreSample.Components
{
    public class SpecialisationList : ViewComponent
    {
        private readonly ISpecialisationRepository _specialisationRepository;

        public SpecialisationList(ISpecialisationRepository specialisationRepository)
        {
            _specialisationRepository = specialisationRepository;
        }

        public IViewComponentResult Invoke()
        {
            var specialisations = _specialisationRepository.AllSpecialisations.OrderBy(s => s.Name);

            return View(specialisations);
        }
    }
}
