using ModSettings;
using Il2Cpp;


namespace NonLethalFlares;

internal class Settings : JsonModSettings
{
    internal static Settings Instance;

    [Name("Enable Sticky Flare Rounds")]
    [Description("Enable or disable flare gun rounds sticking to bears on impact. Its pretty goofy, but defaults to disabled.")]
    public bool StickThemFlaresOnThemBears = false;


    internal Settings() : base("NonLethalFlares")
    {
        Initialize();
    }

    protected void Initialize()
    {
        Instance = this;
        AddToModSettings("Non-Lethal Flares");
        RefreshGUI();
    }
}