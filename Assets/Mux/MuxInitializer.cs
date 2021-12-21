using Mux;
using UnityEngine;

public class MuxInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod()
    {
        Forms.mainThread = System.Threading.SynchronizationContext.Current;
        Forms.Init();
        System.Diagnostics.Debug.Listeners.Add(new TraceListener());
    }
}
