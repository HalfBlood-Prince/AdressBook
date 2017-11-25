using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCon.Models
{
    public class AddressGroup
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime AddedDay { get; set; }

        public AddressGroupType AddressGroupType { get; set; }

        [Display(Name = "Address Group Type")]
        public byte AddressGroupTypeId { get; set; }


    }
}