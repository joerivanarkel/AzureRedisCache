using Application.Persons;

namespace Presentation.Services;

public interface IPersonService
{
    Task<IEnumerable<PersonModel>> GetAllAsync();
}
