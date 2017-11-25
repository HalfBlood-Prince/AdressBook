using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GCon.Models;

namespace GCon.Controllers.api
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();    
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /api/contacts
        [HttpGet]
        public IHttpActionResult GetAddressGroup()
        {
            return Ok(_context.Contacts.ToList());
        }



        //DELETE: /api/Contacts/id
        [HttpDelete]
        public void DeleteContact(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if(contactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();
        }
    }
}
