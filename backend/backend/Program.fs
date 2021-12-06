namespace backend

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
#nowarn "20"

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()
        builder.Services.AddCors(fun options ->
               options.AddDefaultPolicy(fun optionBuilder ->
                   optionBuilder.AllowAnyOrigin()
                   optionBuilder.AllowAnyHeader()
                   optionBuilder.AllowAnyMethod()
                   ())
               ())

        let app = builder.Build()

        app.UseHttpsRedirection()
        app.UseCors()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode
