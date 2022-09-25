using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using InAndOut.Models.ViewModels;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> ExpenseList = _db.Expenses;
            foreach (var obj in ExpenseList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }

            return View(ExpenseList);
        }

        //GET- Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.TypeDropDown = TypeDropDown;
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDownDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM objExp)
        {
            if (ModelState.IsValid)
            {
                //objExp.ExpenseTypeId = 1;
                _db.Expenses.Add(objExp.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objExp);
        }

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);
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
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - Update
        public IActionResult Update(int? id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDownDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }

            expenseVM.Expense = _db.Expenses.Find(id);
            if (expenseVM.Expense == null)
            {
                return NotFound();
            }
            return View(expenseVM);
        }

        //POST - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM objexpense)
        {
            if (ModelState.IsValid)
            {
                //objexpense.ExpenseTypeId = 1;
                _db.Expenses.Update(objexpense.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objexpense);
        }

    }
}
