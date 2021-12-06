namespace backend.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.Linq
open backend

[<ApiController>]
[<Route("user")>]
type UserController (logger : ILogger<UserController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() =
        UserContextFactory().build().users.ToList()
    
    [<HttpPost>]
    member _.Post([<FromBody>] user: User) =
        let userContext = UserContextFactory().build()
        userContext.users.Add(user) |> ignore
        userContext.SaveChanges() |> ignore
        ()

    [<HttpDelete>]
    member _.Delete([<FromBody>] user: User) =
        let userContext = UserContextFactory().build()
        userContext.users.Remove(user) |> ignore
        userContext.SaveChanges() |> ignore
        ()