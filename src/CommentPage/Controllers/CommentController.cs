using System.Linq;
using Microsoft.AspNet.Mvc;
using CommentPage.Models;
using System.Collections.Generic;

namespace CommentPage.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Comment
        public IActionResult Index()
        {
            return View(_context.Comment.ToList().Where(c => c.Main == 0));
        }

        // GET: Comment/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = _context.Comment.Single(m => m.ID == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // GET: Comment/Reply/5
        public IActionResult Reply(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Comment> context = _context.Comment.ToList().Where(m => m.Main == id);

            if (context.Count() <= 0)
            {
                return HttpNotFound();
            }

            return View(context);
        }

        // GET: Comment/Create/5
        public IActionResult Create(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            Comment comment = _context.Comment.Single(m => m.ID == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Comment comment)
        {
            if (comment.ID != 0)
                comment.ID = 0;

            if (ModelState.IsValid)
            {
                _context.Comment.Add(comment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comment/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = _context.Comment.Single(m => m.ID == id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(comment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comment/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = _context.Comment.Single(m => m.ID == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Comment comment = _context.Comment.Single(m => m.ID == id);
            _context.Comment.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
