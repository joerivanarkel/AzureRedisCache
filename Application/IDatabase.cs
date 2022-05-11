using Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IDatabase
{
    DbSet<Person> Persons { get; set; }
}
