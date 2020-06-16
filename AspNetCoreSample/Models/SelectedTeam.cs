using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreSample.Models
{
    public class SelectedTeam
    {
        private readonly AppDbContext _appDbContext;

        public string SelectedTeamId { get; }

        public List<SelectedTeamCandidate> SelectedTeamCandidates { get; set; }

        private SelectedTeam(AppDbContext appDbContext, string selectedTeamId)
        {
            _appDbContext = appDbContext;
            SelectedTeamId = selectedTeamId;
        }

        public static SelectedTeam GetTeam(IServiceProvider services)
        {
            var dbContext = services.GetService<AppDbContext>();

            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var teamId = session.GetString("TeamId") ?? Guid.NewGuid().ToString("N");
            session.SetString("TeamId", teamId);

            return new SelectedTeam(dbContext, teamId);
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
            SelectedTeamCandidates ??= _appDbContext.SelectedTeamCandidates
                .Where(stc => stc.SelectedTeamId == SelectedTeamId)
                .Include(stc => stc.Candidate)
                .ToList();

            return SelectedTeamCandidates;
        }

        public decimal GetSelectedTeamTotalOffer()
        {
            var totalOffer = _appDbContext.SelectedTeamCandidates
                .Where(c => c.SelectedTeamId == SelectedTeamId)
                .Sum(c => c.OfferPrice);

            return totalOffer;
        }

        public decimal GetSelectedTeamTotalRating()
        {
            var totalRating = _appDbContext.SelectedTeamCandidates
                .Where(c => c.SelectedTeamId == SelectedTeamId)
                .Include(s => s.Candidate)
                .Sum(t => t.Candidate.Rating);

            return totalRating;
        }
    }
}
