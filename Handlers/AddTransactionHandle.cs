using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AddUpdateTransaction.Handlers
{
    public class AddTransactionHandle : IHandler<Transaction>
    {
        const string EVENT_TYPE_KEY = "pigeon.eventType";
        const string EVENT_TYPE_VALUE = "walli.TransactionAddedEventV1";
        const string PROJECT_ID = "impactful-shard-374913";
        const string OUTPUT_TOPIC = "TestTopic";

        public async Task Handle(Transaction entity)
        {
            await PublishTransaction(entity);
        }

        public static async Task PublishTransaction(Transaction transaction)
        {
            var topicName = TopicName.FromProjectTopic(PROJECT_ID, OUTPUT_TOPIC);
            var publisher = await PublisherClient.CreateAsync(topicName);

            try
            {
                var message = new PubsubMessage()
                {
                    Data = ByteString.CopyFromUtf8(JsonConvert.SerializeObject(transaction)),
                    Attributes = { { EVENT_TYPE_KEY, EVENT_TYPE_VALUE } }
                };

                await publisher.PublishAsync(message);

                Console.WriteLine($"Published message: {message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error ocurred while publishing message {transaction}: {exception.Message}");
            }
        }
    }
}