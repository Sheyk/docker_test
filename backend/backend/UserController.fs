namespace backend.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open backend

[<ApiController>]
[<Route("user")>]
type UserController (logger : ILogger<UserController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() =
        [|
            { Id = 1; Firstname = "John"; Lastname = "Doe"; }
            { Id = 2; Firstname = "Mary"; Lastname = "Jane"; }
            { Id = 3; Firstname = "Barry"; Lastname = "White"; }
        |]
