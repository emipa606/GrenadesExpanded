using System;
using UnityEngine;
using Verse;

namespace GrenadesExpanded
{
	// Token: 0x02000005 RID: 5
	internal class GrenadesExpendedSettings : Mod
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000209C File Offset: 0x0000029C
		public GrenadesExpendedSettings(ModContentPack mcp) : base(mcp)
		{
			LongEventHandler.ExecuteWhenFinished(new Action(this.GetSettings));
			LongEventHandler.ExecuteWhenFinished(new Action(this.PushDatabase));
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020EC File Offset: 0x000002EC
		public void GetSettings()
		{
			base.GetSettings<GrenadesExpendedMod>();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020F6 File Offset: 0x000002F6
		public override void WriteSettings()
		{
			base.WriteSettings();
			GrenadesExpendedMod.rabbitincident = GrenadesExpendedMod.rabbitincident;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000210A File Offset: 0x0000030A
		private void PushDatabase()
		{
			GrenadesExpendedMod.database = DefDatabase<ThingDef>.AllDefsListForReading;
			this.WriteSettings();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002120 File Offset: 0x00000320
		public override string SettingsCategory()
		{
			return Static.GrenadesExpended;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002138 File Offset: 0x00000338
		public override void DoSettingsWindowContents(Rect rect)
		{
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.Begin(rect);
			listing_Standard.Gap(15f);
			Rect rect2 = listing_Standard.GetRect(Text.LineHeight);
			Widgets.Label(rect2, "Killer Rabbit Incident");
			listing_Standard.Gap(10f);
			listing_Standard.CheckboxLabeled("Enabled ?", ref GrenadesExpendedMod.rabbitincident, "Use this to enable/disble the killer rabbit incident");
			listing_Standard.End();
		}

		// Token: 0x04000004 RID: 4
		private Vector2 scrollPosition = Vector2.zero;

		// Token: 0x04000005 RID: 5
		private float scrollViewHeight = 0f;
	}
}
