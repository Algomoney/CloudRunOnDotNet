using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.Firestore;

namespace CloudRunOnDotNet.Pages
{
    public class AllGuests : PageModel
    {
        private FirestoreDb db = FirestoreDb.Create("PROJECT-ID-HERE");
        
        public IReadOnlyList<DocumentSnapshot> GuestBookQuerySnapshot { get; set; }
        
        public async Task OnGetAsync()
        {
            var guestRef = db.Collection("guestbook");
            var snapshot = await guestRef.GetSnapshotAsync();

            GuestBookQuerySnapshot = snapshot.Documents;
        }
    }
}