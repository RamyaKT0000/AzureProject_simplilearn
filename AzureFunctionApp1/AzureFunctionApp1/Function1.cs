using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Storage;

namespace AzureFunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, 
            [Queue("output"), StorageAccount("AzureWebJobsStorage")]out string outputQueue,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            log.LogInformation(Add());
            string message = $"Execution of trigger function: {myQueueItem} and {Add()}";
            outputQueue = message;
        }

        [FunctionName("FuncAdd")]
        public static string Add()
        {
            int a = 10;
            int b = 20;
            int c = a + b;
            return $"Addition of {a} and {b} is = {c}";
        }
    }
}
