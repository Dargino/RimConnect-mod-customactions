﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RimWorld;
using Verse;

namespace RimConnection
{
    class RemoveAllMedicineAction : Action
    {
        public RemoveAllMedicineAction()
        {
            this.name = "Remove all medicine";
            this.description = "Hope you don't have any injuries any time soon";
            this.category = "Event";
        }

        public override void execute(int amount)
        {
            var currentMap = Find.CurrentMap;

            var allMedicine = currentMap.listerThings.ThingsInGroup(ThingRequestGroup.Medicine).ToList();

            allMedicine.ForEach(medicineThing =>
            {
                Log.Message("Logging one instance of a medicine thing");
                medicineThing.Destroy();
            });

            AlertManager.BadEventNotification("Sorry, but your medicine has been misplaced.... All of it");
        }
    }
}
