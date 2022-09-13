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

        public IActionResult Edit(Guid id)
        {
            var contactToEdit = _contactManager.FindById(id);
            if (contactToEdit != null)
            {
                var contactViewModel = new ContactViewModel
                {
                    Name = contactToEdit.Name,
                    Number = contactToEdit.Number
                };
                ViewData["IdEditContact"] = id;
                return View(contactViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactViewModel contact, Guid id)
        {
            if (ModelState.IsValid)
            {
                var contactToUpdate = new Contact
                {
                    Id = id,
                    Name = contact.Name,
                    Number = contact.Number
                };
                if (await _contactManager.ExistsAsync(contactToUpdate))
                {
                    ModelState.AddModelError("Name", "This contact already exists");
                    return View(contact);
                }

                _contactManager.Update(contactToUpdate);
                await _contactManager.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(contact);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var contactToDelete = _contactManager.FindById(id);
            if (contactToDelete != null)
            {
                _contactManager.Delete(contactToDelete);
                await _contactManager.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
