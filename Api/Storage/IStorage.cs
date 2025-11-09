using Api.Model;
using Api.ModelDto;
using Api.Storage;

namespace Api.Storage
{
    public interface IStorage
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact> AddAsync(Contact contact);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateContactAsync(ContactDto contactDto, int id);
    }
}
