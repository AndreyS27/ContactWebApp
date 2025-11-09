using Api.Model;

namespace Api.Storage
{
    public interface IPaginationStorage : IStorage
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<(List<Contact>, int TotalCount)> GetContactsAsync(int pageNumber, int pageSize);
    }
}
