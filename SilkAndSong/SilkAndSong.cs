using BepInEx;
using HarmonyLib;
using SilkAndSong.Helpers;

namespace SilkAndSong;

[BepInAutoPlugin(id: "io.github.danielstegink.silkandsong")]
[BepInDependency("org.silksong-modding.i18n")]
[BepInDependency("io.github.danielstegink.wishutil")]
public partial class SilkAndSong : BaseUnityPlugin
{
    internal static SilkAndSong instance;

    private void Awake()
    {
        // Put your initialization logic here
        instance = this;

        Log($"Plugin {Name} ({Id}) has loaded!");
    }

    private void Start()
    {
        Harmony harmony = new Harmony(Id);
        harmony.PatchAll();

        SharedData.quest = new SnsQuest();
        WishUtil.QuestData.AddQuest(SharedData.quest);

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