using MediatR;
using Microsoft.AspNetCore.Mvc;
using Parcours_management.Application.Commands;
using Parcours_management.Application.Parcours.Delete;
using Parcours_management.Application.Parcours.Update;
using Parcours_management.Data.Repositories.Parcours;
using System.Reflection;
using Parcours_management.Application.Querries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Parcours_management.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class Parcours
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("parcours", async (CreateParcoursCommand command, ISender sender) =>
            {
                await sender.Send(command);
                return Results.Ok();
            });

            app.MapGet("parcours/{id}", async (int id, ISender sender) =>
            {
                try
                {
                    return Results.Ok(await sender.Send(new GetParcourQuery(id)));
                }

                catch (ParcourstNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });


            app.MapPut("parcours/{id}", async (int id, [FromBody] UpdateParcoursRequest request, ISender sender) =>
            {
                var command = new UpdateParcoursCommand(
                id,
                request.ParcoursName,
                request.ParcoursDescription,
                request.DateCreation);

                await sender.Send(command);
                return Results.NoContent();
            });

            app.MapDelete("parcours/{id}", async (int id, ISender sender) =>
            {
                try
                {
                    await sender.Send(new DeleteParcourCommand(id));
                    return Results.NoContent();
                }

                catch (ParcourstNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });
        }
    }
}


