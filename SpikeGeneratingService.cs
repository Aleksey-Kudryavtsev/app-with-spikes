namespace AppWithLoadSpikes
{
    public class SpikeGeneratingService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => {
                while (true)
                {
                    var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(1.5));
                    var token = cancellationSource.Token;
                    Task.Run(() =>
                    {
                        int counter = 0;
                        double result = 0;
                        while (true)
                        {
                            result = result + Random.Shared.NextDouble();
                            counter++;
                            if (counter % 10000 == 0 && token.IsCancellationRequested)
                            {
                                return;
                            }
                        }
                    }, cancellationSource.Token);
                    Thread.Sleep(TimeSpan.FromSeconds(Random.Shared.Next(300,600)));
                }
            }, stoppingToken);
        }
    }
}
