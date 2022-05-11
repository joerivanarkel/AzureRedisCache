using Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Application.Persons
{

    public class PersonQuery : IPersonQuery
    {
        private readonly IDatabase _database;
        private readonly IDistributedCache _cache;

        public PersonQuery(IDatabase database, IDistributedCache cache)
        {
            _database = database;
            _cache = cache;
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            var cachedPersonList = _cache.GetString("Persons");
            if ((!string.IsNullOrEmpty(cachedPersonList)) && (cachedPersonList != "[]"))
            {
                return JsonConvert.DeserializeObject<IEnumerable<PersonModel>>(cachedPersonList);
            }
            else
            {
                var personList = await _database.Persons.Select( x => new PersonModel
                {
                    Age = x.Age,
                    Name = x.Name,
                    Surname = x.Surname,
                    Id = x.Id

                }).ToListAsync();

                _cache.SetString("Persons", JsonConvert.SerializeObject(personList));
                return personList;
            }
            
        }
    }
}