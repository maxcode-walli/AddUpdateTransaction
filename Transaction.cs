using Google.Cloud.Firestore;

namespace AddUpdateTransaction
{
    [FirestoreData]
    public class Transaction
    {
        [FirestoreProperty]
        public string UserID { get; set; }
        public string TransactionStatus { get; set; }
        [FirestoreProperty]
        public string TransactionId { get; set; }
        [FirestoreProperty]
        public string Uuid { get; set; }
        [FirestoreProperty]
        public string EndToEndId { get; set; }
        [FirestoreProperty]
        public TransactionAmount TransactionAmount { get; set; }
        [FirestoreProperty]
        public string BookingDate { get; set; }
        [FirestoreProperty]
        public string ValueDate { get; set; }
        public string BalanceAfterTransaction { get; set; }
        [FirestoreProperty]
        public string RemittanceInformationUnstructured { get; set; }
        [FirestoreProperty]
        public string RemittanceInformationStructured { get; set; }
        [FirestoreProperty]
        public Account CreditorAccount { get; set; }
        [FirestoreProperty]
        public Account DebtorAccount { get; set; }
        [FirestoreProperty]
        public string ExternalAccountID { get; set; }
    }
    [FirestoreData]
    public class TransactionAmount
    {
        [FirestoreProperty]
        public string Currency { get; set; }
        [FirestoreProperty]
        public float Amount { get; set; }
    }
    [FirestoreData]
    public class Account
    {
        [FirestoreProperty]
        public string Iban { get; set; }
    }
}