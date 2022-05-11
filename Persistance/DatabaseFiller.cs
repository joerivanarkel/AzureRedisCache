using Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public static class DatabaseFiller
    {
        public static void FillPersonTable(Database database)
        {
            database.Persons.Add(new Person { Age = 20, Name = "John", Surname = "Doe" });
            database.Persons.Add(new Person { Age = 30, Name = "Jane", Surname = "Doe" });
            database.Persons.Add(new Person { Age = 40, Name = "Jack", Surname = "Doe" });
            database.SaveChanges();
        }
    }
}