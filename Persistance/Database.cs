using Application;
using Domain.Persons;
using Microsoft.EntityFrameworkCore;
using UserSecrets;

namespace Persistance;

public class Database : DbContext, IDatabase
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(UserSecrets<Database>.GetSecret("sqlconnectionstring"));
    }
}
