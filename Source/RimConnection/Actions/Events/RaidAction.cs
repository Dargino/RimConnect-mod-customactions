﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;

namespace RimConnection
{
    class RaidAction : Action
    {
        public RaidAction()
        {
            this.name = "Raid";
            this.description = "They don't look too happy";
            this.category = "Event";
        }

        public override void execute(int amount)
        {
            var currentMap = Find.CurrentMap;

            var parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, currentMap);

            parms.forced = true;
            parms.raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn;
            parms.raidStrategy = RaidStrategyDefOf.ImmediateAttack;

            var raidWorker = new IncidentWorker_RaidEnemy();
            raidWorker.def = IncidentDef.Named("RaidEnemy");
            raidWorker.TryExecute(parms);

            AlertManager.BadEventNotification("Your viewers have sent a Raid!");
        }
    }
}
