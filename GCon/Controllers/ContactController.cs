using System.Linq;
using System.Web.Mvc;
using GCon.Models;
using GCon.ViewModels;

namespace GCon.Controllers
{
    public class ContactController : Controller
    {

        private ApplicationDbContext _context;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Contacts/ContactList/id
        public ActionResult ContactList(int id)
        {
            var viewModel = new ContactListViewModel
            {
                Id = id,
                Contacts = _context.Contacts.Where(c => c.AddressGroupId == id)
            };

            return View(viewModel);
        }

        public ActionResult NewContact(int id)
        {
            var viewModel = new NewContactViewModel
            {
                Id = id,
                Contact = new Contact()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveContact(int id,Contact contact)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewContactViewModel
                {
                    Id = id,
                    Contact = contact
                };

                return View("NewContact", viewModel);
            }
            if (contact.Id == 0)
            {
                contact.AddressGroupId = id;
                _context.Contacts.Add(contact);
            }
            else
            {
                var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == contact.Id);

                contactInDb.Name = contact.Name;
                contactInDb.Email = contact.Email;
                contactInDb.PhoneNumber = contact.PhoneNumber;
                contactInDb.Address = contact.Address;
            }

            _context.SaveChanges();
            return RedirectToAction("ContactList",new {id = id});
        }

        public ActionResult Edit(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);
            var viewModel = new NewContactViewModel
            {
                Id = contactInDb.AddressGroupId,
                Contact = contactInDb
            };

            return View("NewContact", viewModel);
        }
    }
}