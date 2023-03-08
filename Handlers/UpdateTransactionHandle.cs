using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AddUpdateTransaction.Handlers
{
    public class UpdateTransactionHandle : IHandler<ScoreResponse>
    {
        const string EVENT_TYPE_KEY = "pigeon.eventType";
        const string EVENT_TYPE_VALUE = "walli.TransactionAnomalyScoreCalculatedEventV1";
        const string PROJECT_ID = "impactful-shard-374913";
        const string OUTPUT_TOPIC = "TransactionScores";

        public async Task Handle(ScoreResponse entity)
        {
            entity.Score = 0;
            await PublishScore(entity);
        }

        public static async Task PublishScore(ScoreResponse scoreResponse)
        {
            var topicName = TopicName.FromProjectTopic(PROJECT_ID, OUTPUT_TOPIC);
            var publisher = await PublisherClient.CreateAsync(topicName);

            try
            {
                var message = new PubsubMessage()
                {
                    Data = ByteString.CopyFromUtf8(JsonConvert.SerializeObject(scoreResponse)),
                    Attributes = { { EVENT_TYPE_KEY, EVENT_TYPE_VALUE } }
                };

                await publisher.PublishAsync(message);

                Console.WriteLine($"Published message: {message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error ocurred while publishing message {scoreResponse}: {exception.Message}");
            }
        }
    }
}
