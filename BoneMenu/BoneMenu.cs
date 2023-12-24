namespace TheJanitor.Menu;

internal static class BoneMenu
{
    public static void Setup()
    {
        MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
        MenuCategory subCat = mainCat.CreateCategory("The Janitor", Color.blue);
        subCat.CreateEnumElement("Clear Type", Color.white, Janitor.ClearType.Everything, Janitor.UpdateType);
        subCat.CreateFunctionElement("Clear", Color.white, Janitor.Clear);
        subCat.CreateBoolPreference("Override Fusion Check", Color.red, Preferences.OverrideFusionCheck, Preferences.OwnCategory);
    }
}