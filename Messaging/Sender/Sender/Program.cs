using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Sender;

string connectionString = "Endpoint=sb://bademoasb.servicebus.windows.net/;SharedAccessKeyName=queuepolicy;SharedAccessKey=Xn7QB+RdDiXnnUaYlCGTmWZ+w5IvPvTxYs0m6XPACQg=;EntityPath=queuesample";
string queueName = "queuesample";

var products = new List<Product>()
{
    new(){ Id=1, Name="X", Description="Desc X"},
    new(){ Id=2, Name="A", Description="Desc X"},
    new(){ Id=3, Name="B", Description="Desc X"}

};

//await SendMessageAsync(products);
await ReceiveMessages();

async Task ReceiveMessages()
{
    ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
    var receiver = serviceBusClient.CreateReceiver(queueName);
    var message = await receiver.ReceiveMessageAsync();
    Console.WriteLine(message.Body);

}

async Task SendMessageAsync(List<Product> products)
{
    ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
    ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);
    ServiceBusMessageBatch serviceBusMessageBatch = await serviceBusSender.CreateMessageBatchAsync();

    products.ForEach(p =>
    {
        var serialized = JsonConvert.SerializeObject(p);
        var sbMessage = new ServiceBusMessage(serialized);
        if (!serviceBusMessageBatch.TryAddMessage(sbMessage))
        {
            throw new Exception("Hata oluştu!");
        }
    });
    await serviceBusSender.SendMessagesAsync(serviceBusMessageBatch);
    Console.WriteLine("Mesaj gönderildi");
}