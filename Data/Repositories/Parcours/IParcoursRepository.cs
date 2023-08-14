using Parcours_management.Domain.Models;

namespace Parcours_management.Data.Repositories.Parcours
{
    public interface IParcoursRepository
    {
        Task<Parcour?> GetById(int id);
        IQueryable<Parcour> GetAll();
        Task Add(Parcour parcours);
        Task Update(Parcour parcours);
        void Delete(Parcour parcours);
    }
}
