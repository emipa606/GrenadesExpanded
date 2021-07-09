using System.Collections.Generic;
using Verse;

namespace GrenadesExpanded
{
    // Token: 0x02000003 RID: 3
    internal class GrenadesExpendedMod : ModSettings
    {
        // Token: 0x04000001 RID: 1
        internal static bool rabbitincident = true;

        // Token: 0x04000002 RID: 2
        internal static List<ThingDef> database;

        // Token: 0x06000002 RID: 2 RVA: 0x00002059 File Offset: 0x00000259
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref rabbitincident, "rabbitincident", true);
        }
    }
}