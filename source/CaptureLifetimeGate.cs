using System;
using System.Threading;

namespace CapFrameX.PmcReader.Plugin
{
    // Serializes a running poll with shutdown and rejects polls once stopping starts.
    internal sealed class CaptureLifetimeGate
    {
        private readonly object _sync = new object();
        private int _stopping;

        public bool TryRun(Action action)
        {
            lock (_sync)
            {
                if (Volatile.Read(ref _stopping) != 0)
                    return false;
                action();
                return true;
            }
        }

        public bool Stop(Action action)
        {
            if (Interlocked.Exchange(ref _stopping, 1) != 0)
                return false;
            lock (_sync)
            {
                action();
                return true;
            }
        }
    }
}
