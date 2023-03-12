namespace CharacterRecognitionBP.Interfaces
{
    public interface IWaiter
    {
        ValueTask<bool> ForTrueAsync(Func<bool> predicate, int timeout, int sleepOverride = -1, CancellationToken token = default);
    }
}
