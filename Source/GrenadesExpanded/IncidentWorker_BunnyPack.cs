using RimWorld;
using Verse;

namespace GrenadesExpanded
{
    // Token: 0x02000006 RID: 6
    public class IncidentWorker_BunnyPack : IncidentWorker
    {
        // Token: 0x04000006 RID: 6
        private const float PointsFactor = 1f;

        // Token: 0x04000007 RID: 7
        private const int AnimalsStayDurationMin = 60000;

        // Token: 0x04000008 RID: 8
        private const int AnimalsStayDurationMax = 120000;

        // Token: 0x0600000D RID: 13 RVA: 0x000021A8 File Offset: 0x000003A8
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            //Log.Message("base: " + base.CanFireNowSub(parms) + " enabled: " + GrenadesExpendedMod.rabbitincident);
            if (!base.CanFireNowSub(parms) || !GrenadesExpendedMod.rabbitincident)
            {
                return false;
            }

            var map = (Map) parms.target;

            return ManhunterPackIncidentUtility.TryFindManhunterAnimalKind(parms.points, map.Tile, out _) &&
                   RCellFinder.TryFindRandomPawnEntryCell(out _, map, CellFinder.EdgeRoadChance_Animal);
        }

        // Token: 0x0600000E RID: 14 RVA: 0x0000221C File Offset: 0x0000041C
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map) parms.target;
            var named = DefDatabase<PawnKindDef>.GetNamed("KillerRabbit");
            bool result;
            if (!RCellFinder.TryFindRandomPawnEntryCell(out var intVec, map, CellFinder.EdgeRoadChance_Animal))
            {
                result = false;
            }
            else
            {
                var list = ManhunterPackIncidentUtility.GenerateAnimals(named, map.Tile, parms.points * 1f);
                var rot = Rot4.FromAngleFlat((map.Center - intVec).AngleFlat);
                foreach (var pawn in list)
                {
                    var loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10);
                    GenSpawn.Spawn(pawn, loc, map, rot);
                    pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
                    pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(60000, 120000);
                }

                Find.LetterStack.ReceiveLetter("LetterLabelManhunterPackArrived".Translate(),
                    "ManhunterPackArrived".Translate(named.GetLabelPlural()), LetterDefOf.ThreatBig, list[0]);
                Find.TickManager.slower.SignalForceNormalSpeedShort();
                LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
                LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Important);
                result = true;
            }

            return result;
        }
    }
}