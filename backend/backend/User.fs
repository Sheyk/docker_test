namespace backend

open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions

[<CLIMutable>]
type User = {
    [<Key>] Id: int
    Firstname: string
    Lastname: string
}

type UserContext =
    inherit DbContext
    
    [<DefaultValue>] val mutable users : DbSet<User>
    member this.Users with get() = this.users and set v = this.users <- v

    override _.OnModelCreating builder =
        builder.RegisterOptionTypes()

    override _.OnConfiguring(options: DbContextOptionsBuilder) : unit =
        ()
        
    new () = { inherit DbContext() }
    new (options: DbContextOptions) = { inherit DbContext(options) }
        
type UserContextFactory() =
    member this.connectionString = @"Host=database;Database=docker_test_db;Username=admin;Password=admin"
    
    member this.build _ =
        let optionsBuilder =
            DbContextOptionsBuilder<UserContext>()
                .UseNpgsql(this.connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        let instance = new UserContext(optionsBuilder.Options)
        instance.ChangeTracker.QueryTrackingBehavior <- QueryTrackingBehavior.NoTracking
        instance.ChangeTracker.AutoDetectChangesEnabled <- false
        instance.ChangeTracker.LazyLoadingEnabled <- false
        instance.Database.EnsureCreated() |> ignore
        instance