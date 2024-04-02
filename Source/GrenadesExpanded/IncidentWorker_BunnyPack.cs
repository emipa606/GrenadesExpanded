using RimWorld;
using Verse;

namespace GrenadesExpanded;

public class IncidentWorker_BunnyPack : IncidentWorker
{
    private const float PointsFactor = 1f;

    private const int AnimalsStayDurationMin = 60000;

    private const int AnimalsStayDurationMax = 120000;

    protected override bool CanFireNowSub(IncidentParms parms)
    {
        //Log.Message("base: " + base.CanFireNowSub(parms) + " enabled: " + GrenadesExpendedMod.rabbitincident);
        if (!base.CanFireNowSub(parms) || !GrenadesExpendedMod.rabbitincident)
        {
            return false;
        }

        var map = (Map)parms.target;

        return AggressiveAnimalIncidentUtility.TryFindAggressiveAnimalKind(parms.points, map.Tile, out _) &&
               RCellFinder.TryFindRandomPawnEntryCell(out _, map, CellFinder.EdgeRoadChance_Animal);
    }

    protected override bool TryExecuteWorker(IncidentParms parms)
    {
        var map = (Map)parms.target;
        var named = DefDatabase<PawnKindDef>.GetNamed("KillerRabbit");
        bool result;
        if (!RCellFinder.TryFindRandomPawnEntryCell(out var intVec, map, CellFinder.EdgeRoadChance_Animal))
        {
            result = false;
        }
        else
        {
            var list = AggressiveAnimalIncidentUtility.GenerateAnimals(named, map.Tile, parms.points * 1f);
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