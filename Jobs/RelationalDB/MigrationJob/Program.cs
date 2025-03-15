using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Jobs.RelationalDB.MigrationJob;

class Program
{
    static void Main(string[] args)
    {
        var acceptedEnvironments = new List<string>() { "production", "staging", "development" };

        if (args.Length != 1 || !acceptedEnvironments.Contains(args[0]))
        {
            Console.WriteLine("Error: You must specify environment; such as production, staging, or development\nProgram Exiting...");
            return;
        }

        Console.WriteLine($"Application running for {args[0]}");

        var dbContext = new ApplicationDbContextFactory().CreateDbContext(args);
        dbContext.Database.Migrate();

        Console.WriteLine("Migration completed successfully.");
    }
}
