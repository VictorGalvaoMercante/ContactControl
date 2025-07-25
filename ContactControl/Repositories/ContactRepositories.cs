using ContactControl.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactControl.Repositories
{
    public class ContactRepositories : IContactRepositories
    {
        private readonly BancoContext _bancoContext;

        public ContactRepositories(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContactModel> SearchAll()
        {
            return _bancoContext.Contacts.ToList();
        }

        public ContactModel Add(ContactModel contact)
        {
            // A validação [Required] no ContactModel e ModelState.IsValid no Controller
            // já devem garantir que Email não seja nulo.
            // Se ainda quiser uma validação extra aqui:
            if (string.IsNullOrEmpty(contact.Email))
            {
                throw new ArgumentException("O campo Email não pode ser nulo ou vazio.");
            }

            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges(); // Salva as mudanças no banco de dados
            return contact;
        }
    }
}