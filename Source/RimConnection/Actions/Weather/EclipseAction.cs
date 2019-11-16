﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;

namespace RimConnection
{
    class EclipseAction : Action
    {
        public EclipseAction()
        {
            this.name = "Eclipse";
            this.description = "Time to go where the sun don't shine";
            this.category = "Weather";
        }

        public override void execute(int amount)
        {
            var worker = IncidentDefOf.Eclipse;
            var currentMap = Find.CurrentMap;

            var parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, currentMap);
            parms.forced = true;
            worker.Worker.TryExecute(parms);
            AlertManager.BadEventNotification("Your viewers have sent an Eclipse!");

        }
    }
}
