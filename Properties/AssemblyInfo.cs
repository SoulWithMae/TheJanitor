using System.Reflection;

[assembly: AssemblyTitle(TheJanitor.Main.Description)]
[assembly: AssemblyDescription(TheJanitor.Main.Description)]
[assembly: AssemblyCompany(TheJanitor.Main.Company)]
[assembly: AssemblyProduct(TheJanitor.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + TheJanitor.Main.Author)]
[assembly: AssemblyTrademark(TheJanitor.Main.Company)]
[assembly: AssemblyVersion(TheJanitor.Main.Version)]
[assembly: AssemblyFileVersion(TheJanitor.Main.Version)]
[assembly:
    MelonInfo(typeof(TheJanitor.Main), TheJanitor.Main.Name, TheJanitor.Main.Version,
        TheJanitor.Main.Author, TheJanitor.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]