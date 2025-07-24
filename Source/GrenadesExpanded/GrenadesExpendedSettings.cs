using Mlie;
using UnityEngine;
using Verse;

namespace GrenadesExpanded;

internal class GrenadesExpendedSettings : Mod
{
    private static string currentVersion;

    public GrenadesExpendedSettings(ModContentPack mcp) : base(mcp)
    {
        LongEventHandler.ExecuteWhenFinished(getSettings);
        LongEventHandler.ExecuteWhenFinished(pushDatabase);
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(mcp.ModMetaData);
    }

    private void getSettings()
    {
        GetSettings<GrenadesExpendedMod>();
    }

    private void pushDatabase()
    {
        GrenadesExpendedMod.database = DefDatabase<ThingDef>.AllDefsListForReading;
        WriteSettings();
    }

    public override string SettingsCategory()
    {
        return Static.GrenadesExpended;
    }

    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap(15f);
        var rect2 = listingStandard.GetRect(Text.LineHeight);
        Widgets.Label(rect2, "GrEx.KillerRabbit.label".Translate());
        listingStandard.Gap(10f);
        listingStandard.CheckboxLabeled("GrEx.Enable.label".Translate(), ref GrenadesExpendedMod.rabbitincident,
            "GrEx.Explanation.label".Translate());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("GrEx.Version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}