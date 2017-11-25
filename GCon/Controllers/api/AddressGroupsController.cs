using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GCon.Models;

namespace GCon.Controllers.api
{
    public class AddressGroupsController : ApiController
    {
        private ApplicationDbContext _context;
        public AddressGroupsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //DELETE: api/AddressGroups/id
        [HttpDelete]
        public void DeleteAddressGroup(int id)
        {
            var contacts = _context.Contacts.Where(c => c.AddressGroupId == id);

            foreach (var contact in contacts)
            {
                _context.Contacts.Remove(contact);
            }


            var addressInDb = _context.AddressGroups.SingleOrDefault(add => add.Id == id);
            _context.AddressGroups.Remove(addressInDb);

            _context.SaveChanges();
        }
    }
}
