using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Kafka Producer Started");
Console.WriteLine("Type 'exit' to stop.");

while (true)
{
    Console.Write("Message : ");
    var message = Console.ReadLine() ?? string.Empty;

    if (message.ToLowerInvariant() == "exit")
        break;

    try
    {
        var result = await producer.ProduceAsync(
            "chat-topic",
            new Message<Null, string>
            {
                Value = message
            });

        Console.WriteLine($"Sent : {result.Message.Value}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}