using MediatR;

namespace Parcours_management.Application.Querries
{
    public record GetParcourQuery(int parcourId) : IRequest<ParcoursRespons>;

   

    public record ParcoursRespons(
        int id,
        string ParcoursName,
        string ParcoursDescription,
        DateTime Datecretaion);
}


