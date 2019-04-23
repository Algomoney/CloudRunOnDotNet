using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace CloudRunOnDotNet.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        private FirestoreDb db = FirestoreDb.Create("PROJECT-ID-HERE");

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var fullName = Request.Form["FullName"];
            var message = Request.Form["Message"];
            Console.WriteLine($"Full name: {fullName}\nMessage: {message}");
            
            var guestBook = new GuestBook
            {
                FullName = fullName,
                Message = message
            };

            var docRef = await db.Collection("guestbook").AddAsync(guestBook);
            Console.WriteLine($"Added document with ID: {docRef.Id}");
            
            return RedirectToPage("./Index");
        }
    }
}