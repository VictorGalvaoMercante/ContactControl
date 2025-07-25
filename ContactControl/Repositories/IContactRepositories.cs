using ContactControl.Models;

namespace ContactControl.Repositories
{
    public interface IContactRepositories
    {

        ContactModel Add(ContactModel contact);
    }
}
