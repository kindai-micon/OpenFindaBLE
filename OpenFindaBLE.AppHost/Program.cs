var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OpenFindaBLE>("openfindable");

builder.Build().Run();
