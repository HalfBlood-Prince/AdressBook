using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GCon.Models;

namespace GCon.ViewModels
{
    public class AddressGroupViewModel
    {
        public AddressGroup AddressGroup { get; set; }

        public IEnumerable<AddressGroupType> AddressGroupTypes { get; set; }

    }
}