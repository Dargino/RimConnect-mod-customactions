﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;

namespace RimConnection
{
    class GoldenShowerAction : Action
    {
        public GoldenShowerAction()
        {
            this.name = "Golden Shower";
            this.description = "Gold rains from the skies";
            this.category = "Event";
        }

        public override void execute(int amount)
        {
            var amountOfDrops = 100;

            for(int i = 0; i < amountOfDrops; i ++ )
            {
                DropPodManager.createDropFromDef(ThingDefOf.Gold, amount, name, description, false);
            }

            AlertManager.NormalEventNotification("Your viewers have sent a Golden Shower!");
        }
    }
}
