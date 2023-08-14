using MediatR;
using Parcours_management.Controllers;

namespace Parcours_management.Application.Parcours.Delete
{
    public record DeleteParcourCommand(int parcoursId):IRequest;
    
}
