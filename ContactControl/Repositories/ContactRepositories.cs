using ContactControl.Data;
using ContactControl.Models;

namespace ContactControl.Repositories
{
    public class ContactRepositories : IContactRepositories
    {
        private readonly BancoContext _bancoContext;

        public ContactRepositories(BancoContext bancoContext)
        {
           _bancoContext = bancoContext;
        }

        public ContactModel Add(ContactModel contact)
        {
            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges();
            return contact;
        }
    }
}
