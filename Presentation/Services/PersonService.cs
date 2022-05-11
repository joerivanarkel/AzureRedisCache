using Application.Persons;

namespace Presentation.Services;

public class PersonService : IPersonService
{
    private IPersonQuery _personQuery;

    public PersonService(IPersonQuery personQuery)
    {
        _personQuery = personQuery;
    }

    public async Task<IEnumerable<PersonModel>> GetAllAsync()
    {
        return await _personQuery.GetAllAsync();
    }
}
