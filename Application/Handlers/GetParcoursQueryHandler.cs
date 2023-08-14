using MediatR;
using Microsoft.EntityFrameworkCore;
using Parcours_management.Application.Querries;
using Parcours_management.Data;
using Parcours_management.Data.Repositories.Parcours;
using Parcours_management.Domain.Models;

namespace Parcours_management.Application.Handlers
{
    public sealed class GetParcoursQueryHandler : IRequestHandler<GetParcourQuery, ParcoursRespons>

    {
        private readonly ApplicationDbContext _dbContext;

        public GetParcoursQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ParcoursRespons> Handle(GetParcourQuery request, CancellationToken cancellationToken)
        {
            var parcours = await _dbContext


                .Parcourslist
                .Where(p => p.ParcoursId == request.parcourId)
                .Select(p => new ParcoursRespons(
                p.ParcoursId,
                p.ParcoursName,
                p.ParcoursDescription,
                p.DateCreation))

                .FirstOrDefaultAsync(cancellationToken);


            if (parcours is null)
            {
                throw new ParcourstNotFoundException(request.parcourId);
            }
            return parcours;
        }
    }
}
