using ContactsWeb.Entities;
using ContactsWeb.Models;
using ContactsWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactManager _contactManager;

        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var newContact = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = contact.Name,
                    Number = contact.Number,
                };
                if (await _contactManager.ExistsAsync(newContact))
                {
                    ModelState.AddModelError("Name", "This contact already exists");
                    return View(contact);
                }

                await _contactManager.AddAsync(newContact);
                await _contactManager.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(contact);
        }
    }
}
