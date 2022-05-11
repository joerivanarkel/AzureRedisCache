using Domain.Persons;

namespace Application.Persons
{
    public interface IPersonQuery
    {
        Task<IEnumerable<PersonModel>> GetAllAsync();
    }
}