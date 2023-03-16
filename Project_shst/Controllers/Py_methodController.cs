using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_shst.Areas.Identity.Data;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Controllers
{
    public class Py_methodController : Controller
    {
        private readonly IUnitofWork _context;

        public Py_methodController(IUnitofWork context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            return View(_context.py_method.GetAll());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.py_method.GetAll() == null)
            {
                return NotFound();
            }

            var brand = _context.py_method.GetFirstorDefult(x => x.Id == id);
            //.FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pyment_method py)
        {





            _context.py_method.Add(py);
            _context.py_method.Save();
            return RedirectToAction(nameof(Index));



        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.py_method.GetAll() == null)
            {
                return NotFound();
            }

            var brand = _context.py_method.GetFirstorDefult(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pyment_method brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }



            _context.py_method.Update(brand);
            _context.py_method.Save();


            return RedirectToAction(nameof(Index));

        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.py_method.GetAll() == null)
            {
                return NotFound();
            }

            var brand = _context.py_method.GetFirstorDefult(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.py_method.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AutoAffer'  is null.");
            }
            var brand = _context.py_method.GetFirstorDefult(x => x.Id == id);


            _context.py_method.Remove(brand);


            _context.py_method.Save();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
