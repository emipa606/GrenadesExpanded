using System.Collections.Generic;
using Verse;

namespace GrenadesExpanded;

internal class GrenadesExpendedMod : ModSettings
{
    internal static bool rabbitincident = true;

    internal static List<ThingDef> database;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref rabbitincident, "rabbitincident", true);
    }
}