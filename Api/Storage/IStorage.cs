using Api.Model;
using Api.ModelDto;
using Api.Storage;

namespace Api.Storage
{
    public interface IStorage
    {
        List<Contact> GetContacts();
        Contact Add(Contact contact);
        bool Remove(int id);
        bool UpdateContact(ContactDto contactDto, int id);
    }
}
