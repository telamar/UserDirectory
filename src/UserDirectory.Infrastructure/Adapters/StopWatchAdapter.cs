using System.Diagnostics;
using UserDirectory.Application.Interfaces.Adapters;

namespace UserDirectory.Infrastructure.Adapters
{
    public class StopWatchAdapter : IStopWatchAdapter
    {
        private readonly Stopwatch stopwatch;

        public StopWatchAdapter()
        {
            stopwatch = new Stopwatch();
        }

        public long ElapsedMilliseconds => stopwatch.ElapsedMilliseconds;

        public void Start() => stopwatch.Start();

        public void Stop() => stopwatch.Stop();
    }
}