using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GCon.Models;

namespace GCon.ViewModels
{
    public class ContactListViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public string AddressGroupName { get; set; }  

    }
}