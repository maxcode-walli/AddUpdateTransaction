using Newtonsoft.Json;

namespace AddUpdateTransaction
{
    public class ScoreResponse
    {
        [JsonProperty("userId")]
        public string UserID { get; set; }

        [JsonProperty("externalAccountID")]
        public string ExternalAccountID { get; set; }

        [JsonProperty("transactionID")]
        public string TransactionID { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }
    }
}
