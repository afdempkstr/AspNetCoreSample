using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.Models
{
    public class SpecialisationRepository : ISpecialisationRepository
    {
        private readonly AppDbContext _appDbContext;

        public SpecialisationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Specialisation> AllSpecialisations => _appDbContext.Specialisations;

        public Specialisation GetSpecialisationById(int specializationId)
        {
            return _appDbContext.Specialisations.FirstOrDefault(s => s.Id == specializationId);
        }
    }
}
