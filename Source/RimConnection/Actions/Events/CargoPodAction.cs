﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;

namespace RimConnection
{
    class CargoPodAction : Action
    {
        public CargoPodAction()
        {
            this.name = "Cargo Pods";
            this.description = "A gift from above!";
        }

        public override void execute(int amount)
        {
            var currentMap = Find.CurrentMap;

            var parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, currentMap);
            parms.forced = true;
            new IncidentWorker_ResourcePodCrash().TryExecute(parms);
        }
    }
}
