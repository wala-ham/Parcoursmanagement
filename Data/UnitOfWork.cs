using Parcours_management.Data.Repositories.Parcours;
using Parcours_management.Domain.Models;

namespace Parcours_management.Data
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly ApplicationDbContext _context;
        private readonly IParcoursRepository _parcoursRepository;

        public UnitOfWork(ApplicationDbContext context, IParcoursRepository parcoursRepository)
        {
            _context = context;
            _parcoursRepository = parcoursRepository;

        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
