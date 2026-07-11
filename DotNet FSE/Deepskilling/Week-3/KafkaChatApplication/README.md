# KafkaChatApplication — quick run

Run a local Kafka broker (Redpanda) and then start the Producer and Consumer.


Prerequisite: Docker installed and running.

If `docker` is not found in your terminal, install Docker Desktop for Windows and ensure it's running. Then start Redpanda (Kafka compatible):

```powershell
docker compose up -d
```

If you can't use Docker, point the apps at an existing Kafka cluster by setting `KAFKA_BOOTSTRAP`.

Verify Redpanda is listening on 9092, then in two separate terminals run:

```powershell
dotnet run --project Producer
dotnet run --project Consumer
```

Type messages into the Producer terminal; the Consumer should receive and print them.
