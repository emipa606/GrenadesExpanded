using RimWorld;
using Verse;

namespace GrenadesExpanded
{
    // Token: 0x02000009 RID: 9
    public class DeathActionWorker_KillerRabbit : DeathActionWorker
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000012 RID: 18 RVA: 0x000023AC File Offset: 0x000005AC
        public override RulePackDef DeathRules => RulePackDefOf.Transition_Died;

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000013 RID: 19 RVA: 0x000023C4 File Offset: 0x000005C4
        public override bool DangerousInMelee => true;

        // Token: 0x06000014 RID: 20 RVA: 0x000023D8 File Offset: 0x000005D8
        public override void PawnDied(Corpse corpse)
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

            Log.Message("Bunny died. Nature will take revenge. Secret incident triggered (" + num + ")");
            Find.Storyteller.incidentQueue.Add(qi);
        }
    }
}