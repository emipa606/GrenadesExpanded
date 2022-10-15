using Mlie;
using UnityEngine;
using Verse;

namespace GrenadesExpanded;

internal class GrenadesExpendedSettings : Mod
{
    private static string currentVersion;
    private Vector2 scrollPosition = Vector2.zero;

    private float scrollViewHeight = 0f;

    public GrenadesExpendedSettings(ModContentPack mcp) : base(mcp)
    {
        LongEventHandler.ExecuteWhenFinished(GetSettings);
        LongEventHandler.ExecuteWhenFinished(PushDatabase);
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.GrenadesExpanded"));
    }

    public void GetSettings()
    {
        base.GetSettings<GrenadesExpendedMod>();
    }

    private void PushDatabase()
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap(15f);
        var rect2 = listing_Standard.GetRect(Text.LineHeight);
        Widgets.Label(rect2, "GrEx.KillerRabbit.label".Translate());
        listing_Standard.Gap(10f);
        listing_Standard.CheckboxLabeled("GrEx.Enable.label".Translate(), ref GrenadesExpendedMod.rabbitincident,
            "GrEx.Explanation.label".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("GrEx.Version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}