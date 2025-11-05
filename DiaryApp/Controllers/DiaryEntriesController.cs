using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.
                Where(entry => entry.IsActive == true) // or simply .Where(entry => entry.IsActive)
               .ToList();

            return View(objDiaryEntryList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            // Server-side validation
            ValidateDiaryEntry(obj);

            if (ModelState.IsValid) 
            {
                _db.DiaryEntries.Add(obj); // Adds the new diary entry to the DbSet
                _db.SaveChanges();  // Saves the changes to the database
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        private void ValidateDiaryEntry(DiaryEntry entry)
        {
            // Title validations
            if (string.IsNullOrEmpty(entry.Title))
            {
                ModelState.AddModelError("Title", "Please enter a title!");
            }
            else if (entry.Title.Length < 3 || entry.Title.Length > 100)
            {
                ModelState.AddModelError("Title", "Title must be between 3 and 100 characters!");
            }

            // Content validations
            if (string.IsNullOrEmpty(entry.Content))
            {
                ModelState.AddModelError("Content", "Please enter a content!");
            }
            else if (entry.Content.Length < 3 || entry.Content.Length > 100)
            {
                ModelState.AddModelError("Content", "Content must be between 3 and 100 characters!");
            }

            // Date validation
            if (entry.Created == DateTime.MinValue)
            {
                ModelState.AddModelError("Created", "Please enter/choose a date!");
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if(diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            // Server-side validation
            ValidateDiaryEntry(obj);

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj); // Updates the new diary entry in the DbSet
                _db.SaveChanges();  // Saves the changes to the database
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            // Soft delete - update IsActive to false
            diaryEntry.IsActive = false;
            _db.DiaryEntries.Update(diaryEntry);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
