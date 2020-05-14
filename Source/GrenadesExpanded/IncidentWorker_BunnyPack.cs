using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace GrenadesExpanded
{
	// Token: 0x02000006 RID: 6
	public class IncidentWorker_BunnyPack : IncidentWorker
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000021A8 File Offset: 0x000003A8
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			bool flag = !base.CanFireNowSub(parms) && !GrenadesExpendedMod.rabbitincident;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Map map = (Map)parms.target;
				PawnKindDef named = DefDatabase<PawnKindDef>.GetNamed("KillerRabbit", true);
				IntVec3 intVec;
				result = (ManhunterPackIncidentUtility.TryFindManhunterAnimalKind(parms.points, map.Tile, out named) && RCellFinder.TryFindRandomPawnEntryCell(out intVec, map, CellFinder.EdgeRoadChance_Animal, false, null));
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000221C File Offset: 0x0000041C
		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			PawnKindDef named = DefDatabase<PawnKindDef>.GetNamed("KillerRabbit", true);
			IntVec3 intVec;
			bool flag = !RCellFinder.TryFindRandomPawnEntryCell(out intVec, map, CellFinder.EdgeRoadChance_Animal, false, null);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				List<Pawn> list = ManhunterPackIncidentUtility.GenerateAnimals(named, map.Tile, parms.points * 1f);
				Rot4 rot = Rot4.FromAngleFlat((map.Center - intVec).AngleFlat);
				for (int i = 0; i < list.Count; i++)
				{
					Pawn pawn = list[i];
					IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
					GenSpawn.Spawn(pawn, loc, map, rot, WipeMode.Vanish, false);
					pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, false, false, null, false);
					pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(60000, 120000);
				}
				Find.LetterStack.ReceiveLetter(Translator.Translate("LetterLabelManhunterPackArrived"), TranslatorFormattedStringExtensions.Translate("ManhunterPackArrived", named.GetLabelPlural(-1)), LetterDefOf.ThreatBig, list[0], null, null);
				Find.TickManager.slower.SignalForceNormalSpeedShort();
				LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
				LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Important);
				result = true;
			}
			return result;
		}

		// Token: 0x04000006 RID: 6
		private const float PointsFactor = 1f;

		// Token: 0x04000007 RID: 7
		private const int AnimalsStayDurationMin = 60000;

		// Token: 0x04000008 RID: 8
		private const int AnimalsStayDurationMax = 120000;
	}
}
