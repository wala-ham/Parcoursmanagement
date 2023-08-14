using MediatR;
using Parcours_management.Application.Commands;
using Parcours_management.Data;
using Parcours_management.Data.Repositories.Parcours;
using Parcours_management.Domain.Models;
using System.Threading.Tasks; 

namespace Parcours_management.Application.Handlers
{
    public sealed class CreateParcourCommanHandler : IRequestHandler<CreateParcoursCommand>
    {
        private readonly IParcoursRepository _parcoursRepository;
        private readonly IUnitOfwork _unitOfwork;
        public CreateParcourCommanHandler(IParcoursRepository parcoursRepository, IUnitOfwork unitOfWork)
        {
            _parcoursRepository = parcoursRepository;
            _unitOfwork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateParcoursCommand request, CancellationToken cancellationToken)
        {
            var parcours = new Parcour
            {
                ParcoursName = request.ParcoursName,
                ParcoursDescription = request.ParcoursDescription,
                DateCreation = request.DateCreation
            };
            _parcoursRepository.Add(parcours);
            await _unitOfwork.SaveAsync();
            return Unit.Value;
        }
    }

   
}



