using AspNetCoreSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreSample.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly SelectedTeam _selectedTeam;

        public OfferController(IOfferRepository offerRepository, SelectedTeam selectedTeam)
        {
            _offerRepository = offerRepository;
            _selectedTeam = selectedTeam;
        }

        public IActionResult PlaceOffer()
        {
            return View();
        }


        [HttpPost]
        public IActionResult PlaceOffer(Offer offer)
        {
            if (_selectedTeam.SelectedTeamCandidates.Count == 0)
            {
                ModelState.AddModelError("", "There are no candidates selected, you need to add at least one candidate to the selected team");
            }

            if (ModelState.IsValid)
            {
                _offerRepository.CreateOffer(offer);
                _selectedTeam.ClearTeam();
                return RedirectToAction("OfferComplete");
            }

            return View(offer);
        }

        public IActionResult OfferComplete()
        {
            ViewBag.OfferCompleteMessage = "Your offer has been received, we shall contact you soon";
            return View();
        }
    }
}
