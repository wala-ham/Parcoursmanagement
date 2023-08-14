
using MediatR;

namespace Parcours_management.Application.Commands
{
    public record CreateParcoursCommand(
        string ParcoursName,
        string ParcoursDescription,
        DateTime DateCreation
) : IRequest;

}


