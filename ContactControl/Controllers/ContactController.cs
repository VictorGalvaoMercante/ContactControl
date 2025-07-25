using ContactControl.Models;
using ContactControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepositories _contactRepositories;
        public ContactController(IContactRepositories contactRepositories) 
        {
            _contactRepositories = contactRepositories;
        }

        public IActionResult Index()
        {
            List<ContactModel> listContactMdodel =_contactRepositories.SearchAll();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult DeleteConfirmation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            if (ModelState.IsValid) // Verifica se as validações do modelo foram atendidas
            {
                try
                {
                    _contactRepositories.Add(contact);
                    TempData["MensagemSucesso"] = "Contato adicionado com sucesso!";
                    return RedirectToAction("Index"); // Redireciona para uma lista de contatos, por exemplo
                }
                catch (ArgumentException ex) // Captura a exceção de validação personalizada
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex) // Captura outras exceções (ex: DbUpdateException)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar o contato: " + ex.Message);
                }
            }
            // Se o modelo não for válido ou ocorreu um erro, retorna a View com o modelo para exibir mensagens de erro
            return View(contact);
        }

       
      
    }
}
