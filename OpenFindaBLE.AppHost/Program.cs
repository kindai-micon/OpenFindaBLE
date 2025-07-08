var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("findbleDb")
    .AddDatabase("findble-db");

builder.AddProject<Projects.OpenFindaBLE_Backend>("openfindable")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
