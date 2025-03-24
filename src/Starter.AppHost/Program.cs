using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var password = builder
    .AddParameter("assessments-mssql-password", "$tr0ngPa$$w0rd", secret: true);
var mssql = builder
    .AddSqlServer("assessments-mssql", password, 44000);

var defaultDb = mssql
    .AddDatabase("users-db");

builder.AddProject<Command_Api>("users-command-api")
    .WithReference(defaultDb)
    .WaitFor(defaultDb);

builder.AddProject<Query_Api>("users-query-api")
    .WithReference(defaultDb)
    .WaitFor(defaultDb);

builder.Build().Run();
