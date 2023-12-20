using BoneLib.Notifications;

namespace TheJanitor.Menu;

internal static class BoneMenu
{
    private static Notification EverythingCleared { get; } = new()
    {
        Title = "The Janitor",
        Message = "Cleared every spawnable!",
        Type = NotificationType.Success,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    private static Notification NpcsCleared { get; } = new()
    {
        Title = "The Janitor",
        Message = "Cleared all NPCs!",
        Type = NotificationType.Success,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    private static Notification GunsCleared { get; } = new()
    {
        Title = "The Janitor",
        Message = "Cleared all guns!",
        Type = NotificationType.Success,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    private static Notification MeleeCleared { get; } = new()
    {
        Title = "The Janitor",
        Message = "Cleared all melee!",
        Type = NotificationType.Success,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    private static Notification PropsCleared { get; } = new()
    {
        Title = "The Janitor",
        Message = "Cleared all props!",
        Type = NotificationType.Success,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    
    public static void Setup()
    {
        MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
        MenuCategory subCat = mainCat.CreateCategory("The Janitor", Color.blue);
        subCat.CreateFunctionElement("Clear Everything", Color.red, ClearEverything);
        subCat.CreateFunctionElement("Clear NPCs", Color.yellow, ClearNPCs);
        subCat.CreateFunctionElement("Clear Guns", Color.green, ClearGuns);
        subCat.CreateFunctionElement("Clear Melee", Color.magenta, ClearMelee);
        subCat.CreateFunctionElement("Clear Props", Color.cyan, ClearProps);
    }
    
    private static void ClearEverything()
    {
        var poolees = Object.FindObjectsOfType<AssetPoolee>();
        foreach (var poolee in poolees)
        {
            if (poolee.spawnableCrate.Barcode == "SLZ.BONELAB.Core.DefaultPlayerRig") return;
            poolee.Despawn();
        }
        Notifier.Send(EverythingCleared);
    }
    
    private static void ClearNPCs()
    {
        var poolees = Object.FindObjectsOfType<AssetPoolee>();
        foreach (var poolee in poolees)
        {
            if (poolee.spawnableCrate.Tags.Contains("NPC"))
            {
                poolee.Despawn();
            }
        }
        Notifier.Send(NpcsCleared);
    }
    
    private static void ClearGuns()
    {
        var poolees = Object.FindObjectsOfType<AssetPoolee>();
        foreach (var poolee in poolees)
        {
            if (poolee.spawnableCrate.Tags.Contains("Gun"))
            {
                poolee.Despawn();
            }
        }
        Notifier.Send(GunsCleared);
    }
    
    private static void ClearMelee()
    {
        var poolees = Object.FindObjectsOfType<AssetPoolee>();
        foreach (var poolee in poolees)
        {
            if (poolee.spawnableCrate.Tags.Contains("Melee"))
            {
                poolee.Despawn();
            }
        }
        Notifier.Send(MeleeCleared);
    }
    
    private static void ClearProps()
    {
        var poolees = Object.FindObjectsOfType<AssetPoolee>();
        foreach (var poolee in poolees)
        {
            if (poolee.spawnableCrate.Tags.Contains("Prop"))
            {
                poolee.Despawn();
            }
        }
        Notifier.Send(PropsCleared);
    }
}