namespace UserDirectory.Application.Interfaces.Adapters
{
    public interface IStopWatchAdapter
    {
        long ElapsedMilliseconds { get; }

        void Start();

        void Stop();
    }
}