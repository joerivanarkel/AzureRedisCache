using Application;
using Common;
using Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class Database : DbContext, IDatabase
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DatabaseConnection<Database>.GetSecret("sqlconnectionstring"));
    }
}
