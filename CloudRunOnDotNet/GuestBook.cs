using Google.Cloud.Firestore;

namespace CloudRunOnDotNet
{
    [FirestoreData]
    public class GuestBook
    {
        [FirestoreProperty]
        public string FullName { get; set; }
        [FirestoreProperty]
        public string Message { get; set; }
    }
}