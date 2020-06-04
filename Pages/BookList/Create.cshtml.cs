using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Project.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // Assume the data coming in will be the property for the "Book",
        // So do not have to pass in, in the method "OnPost()"
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        //A handler
        //IActionResult is used bcuz it will redirection to a new Page
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                // adding the book into the queue not yet added to the database 
                await _db.Book.AddAsync(Book);
                //   book into the database 
                await _db.SaveChangesAsync();
                // redirect back to the page 
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}