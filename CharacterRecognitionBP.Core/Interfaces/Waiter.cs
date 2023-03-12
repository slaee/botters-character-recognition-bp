using CharacterRecognitionBP.Interfaces;

namespace CharacterRecognitionBP.Core.Interfaces
{
    public class Waiter : IWaiter
    {
        public async ValueTask<bool> ForTrueAsync(Func<bool> predicate, int timeout, int sleepOverride = -1, CancellationToken token = default)
        {
            return await ForTrueAsync(predicate, null, timeout, sleepOverride, token);
        }

        private async ValueTask<bool> ForTrueAsync(Func<bool> predicate, Action? loopFunction, int timeout, int sleepOverride = -1, CancellationToken token = default)
        {
            try
            {
                int counter = 0;
                while (!predicate() && !token.IsCancellationRequested)
                {
                    if (timeout > 0 && counter >= timeout)
                        return false;
                    loopFunction?.Invoke();
                    await Task.Delay(sleepOverride == -1 ? 20 : sleepOverride, token);
                    counter++;
                }
                return true;
            }
            catch { }
            return false;
        }
    }
}
