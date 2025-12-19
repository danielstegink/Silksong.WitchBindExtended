using BepInEx;
using HarmonyLib;
using WitchBindExtended.Settings;

namespace WitchBindExtended;

[BepInAutoPlugin(id: "io.github.danielstegink.witchbindextended")]
public partial class WitchBindExtended : BaseUnityPlugin
{
    internal static WitchBindExtended Instance { get; private set; }

    private void Awake()
    {
        // Put your initialization logic here
        Instance = this;

        Harmony harmony = new Harmony(Id);
        harmony.PatchAll();

        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    private void Start()
    {
        ConfigSettings.Initialize(Config);
    }

    /// <summary>
    /// Shared logger for the mod
    /// </summary>
    /// <param name="message"></param>
    internal void Log(string message)
    {
        Logger.LogInfo(message);
    }
}