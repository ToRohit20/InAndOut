using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> obj = _db.ExpenseTypes;
            return View(obj);
        }

        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expenseCategory)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(expenseCategory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseCategory);
        }

        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType expenseCategory)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(expenseCategory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseCategory);
        }
    }
}
