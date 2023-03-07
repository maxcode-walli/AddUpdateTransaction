using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AddUpdateTransaction.Handlers;

namespace AddUpdateTransaction
{
    public class AddUpdateTransaction : IHttpFunction
    {
        public async Task HandleAsync(HttpContext context)
        {
            var req = context.Request;
            if (req.Method == "POST")
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<Transaction>(requestBody);
                await new AddTransactionHandle().Handle(data);
            }
            else if (req.Method == "PUT")
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<ScoreResponse>(requestBody);
                await new UpdateTransactionHandle().Handle(data);
            }
        }
    }
}