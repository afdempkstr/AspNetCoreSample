using AspNetCoreSample.Migrations;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Models
{
    public class SelectedTeam
    {
        private readonly AppDbContext _appDbContext;

        public string SelectedTeamId { get; set; }

        public List<SelectedTeamCandidate> SelectedTeamCandidates { get; set; }

        public SelectedTeam(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddToTeam(Candidate candidate, int offerPrice)
        {
            var selectedTeamCandidate = _appDbContext.SelectedTeamCandidates.SingleOrDefault(
                s => s.Candidate.Id == candidate.Id && s.SelectedTeamId == SelectedTeamId);

            if (selectedTeamCandidate == null)
            {
                selectedTeamCandidate = new SelectedTeamCandidate()
                {
                    Candidate = candidate,
                    SelectedTeamId = SelectedTeamId,
                    OfferPrice = offerPrice
                };

                _appDbContext.SelectedTeamCandidates.Add(selectedTeamCandidate);
            }
            else
            {
                selectedTeamCandidate.OfferPrice = offerPrice;
            }

            _appDbContext.SaveChanges();
        }

        public void RemoveFromTeam(Candidate candidate)
        {
            var selectedTeamCandidate = _appDbContext.SelectedTeamCandidates.SingleOrDefault(
                s => s.Candidate.Id == candidate.Id && s.SelectedTeamId == SelectedTeamId);

            if (selectedTeamCandidate != null)
            {
                _appDbContext.SelectedTeamCandidates.Remove(selectedTeamCandidate);
                _appDbContext.SaveChanges();
            }
        }

        public void ClearTeam()
        {
            var items = _appDbContext.SelectedTeamCandidates.Where(stc => stc.SelectedTeamId == SelectedTeamId);
            _appDbContext.SelectedTeamCandidates.RemoveRange(items);
            _appDbContext.SaveChanges();
        }

        public List<SelectedTeamCandidate> GetSelectedTeamCandidates()
        {
            return SelectedTeamCandidates ?? _appDbContext.SelectedTeamCandidates
                .Where(stc => stc.SelectedTeamId == SelectedTeamId)
                .Include(stc => stc.Candidate)
                .ToList();
        }

        public decimal GetSelectedTeamTotalOffer()
        {
            return 0m;
        }

        public decimal GetSelectedTeamTotalRating()
        {
            return 0m;
        }
    }
}
