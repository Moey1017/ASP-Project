using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Project.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        // because we want to update things so we need this to connect to the database
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        // getting the book by it's ID 
        public async Task<IActionResult> OnGet(int? id)// ? means might not be any id if use to create a book
        {
            Book = new Book();
            if (id == null) // for create 
            {
                return Page();
            }
            
            // for update 
            Book = await _db.Book.FindAsync(id); // or use _db.Book.FirstOrDefaultAsync(u => u.Id = id);, both same 
            if(Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Book.Id == 0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book); // update everything 
                }
                //var BookFromDb = await _db.Book.FindAsync(Book.Id);
                //BookFromDb.Name = Book.Name;
                //BookFromDb.Author = Book.Author;
                //BookFromDb.ISBN = Book.ISBN;

                //save it to database 
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}