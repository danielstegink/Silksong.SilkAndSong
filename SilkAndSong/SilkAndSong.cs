using BepInEx;
using HarmonyLib;
using SilkAndSong.Helpers;
using TeamCherry.Localization;

namespace SilkAndSong;

[BepInAutoPlugin(id: "io.github.danielstegink.silkandsong")]
public partial class SilkAndSong : BaseUnityPlugin
{
    internal static SilkAndSong instance;

    private void Awake()
    {
        // Put your initialization logic here
        instance = this;

        // todo - modify this to install individual patches; i need to add the get language patch in the start method
        // the language get patch needs to grab my quest description and replace it w dynamic values
        // round bonuses to nearest 0.01
        // for dmg bonuses, make sure to note w + or - (shouldn't be possible to get -, but i want to check regardless)

        // also - go into quest manager and figure out how to add quest to manager and completion journal
        // may not need to add it to journal, but i should check regardless
        Log($"Plugin {Name} ({Id}) has loaded!");
    }

    private void Start()
    {
        Harmony harmony = new Harmony(Id);
        harmony.PatchAll();

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