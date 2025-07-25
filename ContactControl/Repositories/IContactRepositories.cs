using ContactControl.Models;

namespace ContactControl.Repositories
{
    public interface IContactRepositories
    {
        List<ContactModel> SearchAll();
        ContactModel Add(ContactModel contact);
    }
}
