namespace backend.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("")>]
type RootController (logger : ILogger<RootController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() = "backend app running"
