 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoCSharp_CRUD.Models;

namespace MongoCSharp_CRUD.Controllers
{
    public class PeopleController : Controller
    {
        private readonly DataManager _context=new DataManager();

        public PeopleController()
        {
           // _context = context;
        }

        // GET: People
        public  IActionResult Index()
        {
            return View( _context.GetAllPerson());
        }

        // GET: People/Details/5
        public  IActionResult Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person =  _context.GetPersonById(id);
               
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Family,WebSite")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.InsertPerson(person);
               
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Edit/5
        public  IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person =  _context.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,Name,Family,WebSite")] Person person)
        {
            if (id != person._id.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.GetPersonById(id);
              
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
              _context.DeletePerson(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            if (_context.GetPersonById(id)!=null)
                return true;
            return false;
                     
        }
    }
}
