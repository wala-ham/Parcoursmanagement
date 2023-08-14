using Microsoft.EntityFrameworkCore;
using Parcours_management.Domain.Models;

namespace Parcours_management.Data.Repositories.Parcours
{
    public class ParcoursRepository : IParcoursRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Parcour> _set;
        public ParcoursRepository(ApplicationDbContext context) 
        { 
            _context = context;
            _set = context.Set<Parcour>();

        }
        public async  Task Add(Parcour parcours)
        {
            await _set.AddAsync(parcours);
        }

        public void Delete(Parcour parcours)
        {
            _set.Remove(parcours);
        }

        public IQueryable<Parcour> GetAll()
        {
            return _set;
        }


        public async Task<Parcour?> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task Update(Parcour parcours)
        {
            _context.Entry(parcours).State = EntityState.Modified;
        }
    }
}
