namespace TheJanitor;

internal static class Janitor
{
    #region Notifications
    
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
    private static Notification DecalsCleared { get; } = new()
    {
        Title = "The Janitor",
        Message = "Cleared all decals!",
        Type = NotificationType.Success,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    private static Notification InFusionServer { get; } = new()
    {
        Title = "The Janitor",
        Message = "You are in a fusion server! This would cause desync. Not doing it.",
        Type = NotificationType.Error,
        PopupLength = 1f,
        ShowTitleOnPopup = true
    };
    
    #endregion

    private static ClearType _clearType = ClearType.Everything;
    
    public static void UpdateType(ClearType clearType)
    {
        _clearType = clearType;
    }

    public static void Clear()
    {
        if (Main.FusionInstalled && !Preferences.OverrideFusionCheck.Value && (LabFusion.Network.NetworkInfo.IsClient || LabFusion.Network.NetworkInfo.IsServer) && _clearType != ClearType.Decals)
        {
            Notifier.Send(InFusionServer);
            return;
        }
        switch (_clearType)
        {
            case ClearType.Everything:
                ClearEverything();
                break;
            case ClearType.Npcs:
                ClearNPCs();
                break;
            case ClearType.Guns:
                ClearGuns();
                break;
            case ClearType.Melee:
                ClearMelee();
                break;
            case ClearType.Props:
                ClearProps();
                break;
            case ClearType.Decals:
                ClearDecals();
                break;
            default:
                ModConsole.Error("Invalid clear type!");
                break;
        }
    }
    
    #region Clearing
    
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
    
    private static void ClearDecals()
    {
        var poolees = Object.FindObjectsOfType<AssetPoolee>();
        foreach (var poolee in poolees)
        {
            if (poolee.spawnableCrate.Tags.Contains("Decal"))
            {
                poolee.Despawn();
            }
        }
        Notifier.Send(DecalsCleared);
    }
    
    #endregion
    
    internal enum ClearType
    {
        Everything,
        Npcs,
        Guns,
        Melee,
        Props,
        Decals
    }
}