using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCon.Models;
using GCon.ViewModels;
using System.Data.Entity;

namespace GCon.Controllers
{
    public class GroupController : Controller
    {

        private ApplicationDbContext _context;

        public GroupController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Group
        public ActionResult Index()
        {
            var addressGroups = _context.AddressGroups.Include(add => add.AddressGroupType).ToList();

            return View(addressGroups);
        }


        // GET: Group/NewGroup
        public ActionResult NewGroup()
        {
            var viewModel = new AddressGroupViewModel
            {
                AddressGroupTypes = _context.AddressGroupTypes.ToList(),
                AddressGroup = new AddressGroup()
            };

            return View(viewModel);
        }



        // GET: Group/Save/AddressGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AddressGroup addressGroup)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddressGroupViewModel
                {
                    AddressGroupTypes = _context.AddressGroupTypes.ToList(),
                    AddressGroup = addressGroup
                };

                return View("NewGroup", viewModel);
            }
            if (addressGroup.Id == 0)
            {

                addressGroup.AddedDay = DateTime.Now;

                _context.AddressGroups.Add(addressGroup);
            }
            else
            {
                var addressGroupInDb = _context.AddressGroups.SingleOrDefault(add => add.Id == addressGroup.Id);

                addressGroupInDb.Name = addressGroup.Name;
                addressGroupInDb.AddressGroupTypeId = addressGroup.AddressGroupTypeId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Group/Edit/id
        public ActionResult Edit(int id)
        {
            var viewModel = new AddressGroupViewModel
            {
                AddressGroup = _context.AddressGroups.SingleOrDefault(add => add.Id == id),
                AddressGroupTypes = _context.AddressGroupTypes.ToList()
            };

            return View("NewGroup", viewModel);
        }
    }
}