using RimWorld;
using Verse;
using Verse.AI.Group;

namespace GrenadesExpanded;

public class DeathActionWorker_KillerRabbit : DeathActionWorker
{
    public override RulePackDef DeathRules => RulePackDefOf.Transition_Died;

    public override bool DangerousInMelee => true;

    public override void PawnDied(Corpse corpse, Lord prevLord)
    {
        int num;
        if (corpse.InnerPawn.ageTracker.CurLifeStageIndex == 0)
        {
            num = 100;
        }
        else
        {
            num = corpse.InnerPawn.ageTracker.CurLifeStageIndex == 1 ? 75 : 50;
        }

        var num2 = Rand.Range(60, 600);
        StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, corpse.Map);
        var parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, corpse.Map);
        var qi = new QueuedIncident(new FiringIncident(CrazyRabbitIncidentDefOf.CrazyRabbitIncident, null, parms),
            Find.TickManager.TicksGame + num2);
        if (GenDate.DaysPassed < 90 || Rand.Range(1, 10) != 1)
        {
            return;
        }

        Log.Message($"Bunny died. Nature will take revenge. Secret incident triggered ({num})");
        Find.Storyteller.incidentQueue.Add(qi);
    }
}