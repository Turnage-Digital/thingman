using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ThingMan.Core.Commands;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Commands;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan.App;

public static class ThingDefsApi
{
    public static IEndpointConventionBuilder MapThingDefsApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/thing-defs")
            .RequireAuthorization();

        retval.MapPost("/create", async (
                CreateThingDefCommand command,
                IHandleCommand<CreateThingDefCommand, ThingDef> commandHandler,
                IMapper mapper,
                ClaimsPrincipal claimsPrincipal
            ) =>
            {
                Log.Information("/thing-def/create called: {TraceId} {Command}", command.TraceId, command);

                var identity = (ClaimsIdentity)claimsPrincipal.Identity!;
                command.UserId = identity.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

                var commandResult = await commandHandler.HandleAsync(command);
                if (!commandResult.Succeeded)
                {
                    var message = commandResult.Errors
                        .Aggregate($"Command: {command} - failed:", (m, coreError) => $"{m} {coreError.Message}");
                    Log.Error("{message}", message);
                    return Results.Problem("Failed to create ThingDef", statusCode: 500);
                }

                var result = commandResult.Result!;
                var dto = mapper.Map<ThingDefDto>(result);

                return Results.Created($"/thing-defs/{dto.Id}", dto);
            })
            .Produces(Status401Unauthorized)
            .Produces<ThingDefDto>(Status201Created)
            .Produces<ProblemDetails>(Status500InternalServerError);

        return retval;
    }
}