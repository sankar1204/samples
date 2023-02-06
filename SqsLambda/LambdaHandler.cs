using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaTest;

public class LambdaHandler
{
    /// <summary>
    /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
    /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
    /// region the Lambda function is executed in.
    /// </summary>
    public LambdaHandler()
    {

    }


    /// <summary>
    /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
    /// to respond to SQS messages.
    /// </summary>
    /// <param name="evnt"></param>
    /// <param name="context"></param>
    /// <returns><see cref="SQSBatchResponse"/></returns>
    public async Task<SQSBatchResponse> handleRequest(SQSEvent evnt, ILambdaContext context)
    {
        LambdaLogger.Log("================handleRequest invoked==============");
        List<SQSBatchResponse.BatchItemFailure> batchFailures = new List<SQSBatchResponse.BatchItemFailure>();
        foreach (var message in evnt.Records)
        {
            if (!string.IsNullOrEmpty(ProcessMessageAsync(message, context))){
                batchFailures.Add(new SQSBatchResponse.BatchItemFailure { ItemIdentifier = message.MessageId });
            }
        }
        return await Task.FromResult(new SQSBatchResponse(batchFailures));
    }

    private string ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        LambdaLogger.Log("================Message details start==============");
       
        //if (message.Attributes != null)
        //{
        //    foreach (var atrribute in message.Attributes)
        //    {
        //        LambdaLogger.Log($"key: {atrribute.Key} value: {atrribute.Value}");
        //    }
        //}
        //LambdaLogger.Log("Body");
        var order = JsonConvert.DeserializeObject<Order>(message.Body);
        if (int.Parse(order.Id) % 2 == 0) {
            return message.MessageId;
        }
        LambdaLogger.Log($"{message.Body}");
        //context.Logger.LogInformation($"Processed message {message.Body}");

        // TODO: Do interesting work based on the new message
        //Console.WriteLine("================Message details end==============");
        return string.Empty;
    }
}