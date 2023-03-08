using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AddUpdateTransaction.Handlers;
using System.Net;

namespace AddUpdateTransaction
{
    public class AddUpdateTransaction : IHttpFunction
    {
        public async Task HandleAsync(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            response.Headers.Append("Access-Control-Allow-Origin", "*");
            if (HttpMethods.IsOptions(request.Method))
            {
                response.Headers.Append("Access-Control-Allow-Methods", "POST, PUT");
                response.Headers.Append("Access-Control-Allow-Headers", "*");
                response.StatusCode = (int)HttpStatusCode.NoContent;
                return;
            }
            if (request.Method == "POST")
            {
                string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<Transaction>(requestBody);
                await new AddTransactionHandle().Handle(data);
            }
            else if (request.Method == "PUT")
            {
                string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<ScoreResponse>(requestBody);
                await new UpdateTransactionHandle().Handle(data);
            }
        }
    }
}