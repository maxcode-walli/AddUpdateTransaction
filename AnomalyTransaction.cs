using Google.Cloud.Firestore;

namespace AddUpdateTransaction
{
    [FirestoreData]
    public class AnomalyTransaction: Transaction
    {
        public bool IsAnomaly { get; set; }
    }
}
