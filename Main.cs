namespace TheJanitor;

public class Main : MelonMod
{
    internal const string Name = "TheJanitor";
    internal const string Description = "A spawnable cleaner.";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "1.0.1";
    internal const string DownloadLink = "https://bonelab.thunderstore.io/package/SoulWithMae/TheJanitor/";

    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
        BoneMenu.Setup();
    }
}