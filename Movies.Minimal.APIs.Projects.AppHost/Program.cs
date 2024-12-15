var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.EndPoint_Minimal_Api>("endpoint-minimal-api");

builder.Build().Run();
