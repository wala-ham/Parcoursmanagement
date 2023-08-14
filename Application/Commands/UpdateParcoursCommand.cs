using MediatR;

namespace Parcours_management.Application.Parcours.Update
{
    public record UpdateParcoursCommand(
        int parcourId,
        string ParcoursName,
        string ParcoursDescription,
        DateTime DateCreation
) : IRequest;


    public record UpdateParcoursRequest(
       string ParcoursName,
       string ParcoursDescription,
       DateTime DateCreation
);
}


