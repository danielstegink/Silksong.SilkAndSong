using BepInEx;
using HarmonyLib;
using SilkAndSong.Helpers;

namespace SilkAndSong;

[BepInAutoPlugin(id: "io.github.danielstegink.silkandsong")]
public partial class SilkAndSong : BaseUnityPlugin
{
    internal static SilkAndSong instance;

    private void Awake()
    {
        // Put your initialization logic here
        instance = this;
        Harmony harmony = new Harmony(Id);
        harmony.PatchAll();

        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    private void Start()
    {
        ConfigSettings.Initialize(Config);
    }

    /// <summary>
    /// Shared logger for external classes
    /// </summary>
    /// <param name="message"></param>
    internal void Log(string message)
    {
        Logger.LogInfo(message);
    }
}