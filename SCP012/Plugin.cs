namespace SCP012;

using Exiled.API.Features;
using SCP012.Logic;
using System;

public class Plugin : Plugin<Config>
{
    public override string Name => "SCP-012";

    public override string Author => "Smusi Jarvis";

    public override Version Version => new(1, 3, 0);

    public override Version RequiredExiledVersion => new Version(8, 9, 7);

    public static Plugin Singleton { get; private set; }

    public SCP012 Handler { get; private set; }

    public override void OnEnabled()
    {
        Singleton = this;
        RegisterEvents();
        
        Log.Info("Edited by MMDDKK6500 for Apollo Space Server!");

        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        UnRegisterEvents();

        base.OnDisabled();
    }

    private void RegisterEvents()
    {
        Handler = new();

        Exiled.Events.Handlers.Server.RoundStarted += Handler.OnRoundStarted;
        Exiled.Events.Handlers.Server.RoundEnded += Handler.OnRoundEnded;
    }

    private void UnRegisterEvents()
    {
        Exiled.Events.Handlers.Server.RoundStarted -= Handler.OnRoundStarted;
        Exiled.Events.Handlers.Server.RoundEnded -= Handler.OnRoundEnded;

        Handler = null;
        Singleton = null;
    }
}