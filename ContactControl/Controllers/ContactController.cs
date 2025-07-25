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
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepositories.Add(contact);
            return RedirectToAction("Index");

        }
    }
}
